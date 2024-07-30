using GC.Application.DTOs.External.GoogleCalendar;
using GC.Application.Services.External.GoogleCalendar;
using GC.Core.Entityes;
using GC.Core.Enums;
using GC.Core.Repositories;
using GC.Infrastructure.Integrations.GoogleCalendar.Services;
using MediatR;

namespace GC.Application.CQRS.Commands.Atentimentos
{
    public class AtendimentoCommandHandler : IRequestHandler<AtendimentoCommand, Unit>
    {

        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IGoogleCalendarService _googleCalendarService;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IServicoRepository _servicoRepository;


        public AtendimentoCommandHandler(
            IAtendimentoRepository atendimentoRepository,
            IMedicoRepository medicoRepository,
            IGoogleCalendarService googleCalendarService,
            IPacienteRepository pacienteRepository,
            IServicoRepository servicoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
            _medicoRepository = medicoRepository;
            _googleCalendarService = googleCalendarService;
            _pacienteRepository = pacienteRepository;
            _servicoRepository = servicoRepository;
        }


        public async Task<Unit> Handle(AtendimentoCommand request, CancellationToken cancellationToken)
        {

            var idAgenda = await _medicoRepository.GetByIdAsync(request.IdMedico);
            var disponivel = await _googleCalendarService.VerificarIndisponibilidade(request.Inicio, request.Fim, idAgenda.IdCalendarAgenda);

            if(!disponivel)
                return default(Unit);

            var emailPaciente = await _pacienteRepository.GetByIdAsync(request.IdPaciente);
            var servico = await _servicoRepository.GetByIdAsync(request.IdServico);

            var evento = new GoogleAgendaInputModel(emailPaciente.Email, "Agendamento " + servico.Nome, servico.Descricao, request.Inicio, request.Fim);

            var agendar = _googleCalendarService.CriarAgendaGoogle(evento, idAgenda.IdCalendarAgenda);


            if (agendar.Id < 0)
                return default(Unit);
                 
            var atendimento =  new Atendimento(
                      request.IdPaciente,
                      request.IdMedico,
                      request.IdServico,
                      request.Convenio,
                      request.Inicio,
                      request.Fim,
                      request.TipoAtendimento,
                      request.IdEvento);

            var gravar = await _atendimentoRepository.Agendar(atendimento, idAgenda.IdCalendarAgenda);



            return Unit.Value;
        }


        //TODO:[] agendamento
        //TODO:[x] agendamento - Buscar o id da agenda do medico
        //TODO:[x] agendamento - Buscar o email do paciente
        //TODO:[x] agendamento - Buscrar o servico
        //TODO:[x] agendamento - verificar disponibilidade pela agenda
        //TODO:[] agendamento -  Gravar na agenda.
        //TODO:[] agendamentoe - Gravar na base de dados com o id do evento
    }
}
