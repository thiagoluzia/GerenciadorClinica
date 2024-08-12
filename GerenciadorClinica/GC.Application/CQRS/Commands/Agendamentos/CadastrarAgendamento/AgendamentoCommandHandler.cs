using GC.Application.DTOs.External.GoogleCalendar;
using GC.Application.Services.External.GoogleCalendar;
using GC.Core.Entityes;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Agendamentos.CadastrarAgendamento
{
    public class AgendamentoCommandHandler : IRequestHandler<AgendamentoCommand, int>
    {

        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IGoogleCalendarService _googleCalendarService;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IServicoRepository _servicoRepository;


        public AgendamentoCommandHandler(
            IAgendamentoRepository atendimentoRepository,
            IMedicoRepository medicoRepository,
            IGoogleCalendarService googleCalendarService,
            IPacienteRepository pacienteRepository,
            IServicoRepository servicoRepository)
        {
            _agendamentoRepository = atendimentoRepository;
            _medicoRepository = medicoRepository;
            _googleCalendarService = googleCalendarService;
            _pacienteRepository = pacienteRepository;
            _servicoRepository = servicoRepository;
        }


        public async Task<int> Handle(AgendamentoCommand request, CancellationToken cancellationToken)
        {

            var medico = await _medicoRepository.GetByIdAsync(request.IdMedico);
            //var indisponivel = await _googleCalendarService.VerificarIndisponibilidade(request.Inicio, request.Fim, medico.IdCalendarAgenda);
            var disponivel = await _agendamentoRepository. AgendamentoDisponivel(request.Inicio, request.Fim, medico.Id);

            if (!disponivel)
                return default;

            var emailPaciente = await _pacienteRepository.GetByIdAsync(request.IdPaciente);
            var servico = await _servicoRepository.GetByIdAsync(request.IdServico);

            var evento = new GoogleAgendaInputModel(emailPaciente.Email, "Agendamento " + servico.Nome, servico.Descricao, request.Inicio, request.Inicio.AddMinutes(servico.Duracao));

            var agendar = await _googleCalendarService.CriarEvento(evento, medico.IdCalendarAgenda);


            if (string.IsNullOrEmpty(agendar.Id))
                return default;

            var agendamento = new Agendamento(
                      request.IdPaciente,
                      request.IdMedico,
                      request.IdServico,
                      request.Convenio,
                      request.Inicio,
                      request.Inicio.AddMinutes(servico.Duracao),
                      request.TipoAtendimento,
                      agendar.Id);

            var gravar = await _agendamentoRepository.Agendar(agendamento, medico.IdCalendarAgenda);



            return agendamento.Id;
        }
    }
}
