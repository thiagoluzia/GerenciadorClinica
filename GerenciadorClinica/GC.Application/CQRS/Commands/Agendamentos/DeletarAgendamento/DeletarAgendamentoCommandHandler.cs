using GC.Core.Repositories;
using GC.Infrastructure.Integrations.GoogleCalendar.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Application.CQRS.Commands.Agendamentos.DeletarAgendamento
{
    public class DeletarAgendamentoCommandHandler : IRequestHandler<DeletarAgendamentoCommand, Unit>
    {

        private readonly IAgendamentoRepository     _agendamentoRepository;
        private readonly IMedicoRepository          _medicoRepository;
        private readonly IApiGoogleCalendaService   _apiGoogleCalendaService;


        public DeletarAgendamentoCommandHandler(
            IAgendamentoRepository      repository,
            IMedicoRepository           medicoRepository,
            IApiGoogleCalendaService    apiGoogleCalendaService)
        {
            _agendamentoRepository      = repository;
            _medicoRepository           = medicoRepository;
            _apiGoogleCalendaService    = apiGoogleCalendaService;
        }


        public async  Task<Unit> Handle(DeletarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = await _agendamentoRepository.AgendamentoById(request.Id);

            if(agendamento is not null)
            {
                var idMedico = agendamento.IdMedico;

                var result = await _agendamentoRepository.DeletarAgendamento(agendamento.Id);

                if (result > 0)
                    await DeletardaGoogleCalendar(agendamento.IdEvento, idMedico);
            }
                
            return new Unit();
        }

        private async Task DeletardaGoogleCalendar(string? idEvento, int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            if (!string.IsNullOrEmpty(medico.IdCalendarAgenda))
            {
                var t = await _apiGoogleCalendaService.DeletarEventoAgendaGoogle(idEvento, medico.IdCalendarAgenda);
            }

        }
    }
}
