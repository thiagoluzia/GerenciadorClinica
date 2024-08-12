using GC.Application.DTOs.External.GoogleCalendar;
using GC.Infrastructure.Integrations.GoogleCalendar.Models;
using GC.Infrastructure.Integrations.GoogleCalendar.Services;
using Google.Apis.Calendar.v3.Data;

namespace GC.Application.Services.External.GoogleCalendar
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private readonly IApiGoogleCalendaService _service;


        public GoogleCalendarService(IApiGoogleCalendaService service)
        {
            _service = service;
        }


        public async Task<Event> AtualizarEventoAgendaGoogle(string idEvento, GoogleAgendaInputModel request, string agendaId)
        {
            return await _service.AtualizarEventoAgendaGoogle(idEvento, new EventoGoogleAgenda
            {
                Descricao = request.Descricao,
                Email = request.Email,
                Fim = request.Fim,
                Inicio = request.Inicio,
                Resumo = request.Resumo
            }, agendaId);
        }

        public async Task<Event> CriarEvento(GoogleAgendaInputModel request, string agendaId)
        {
            return await _service.CriarEventoAgendaGoogle(new EventoGoogleAgenda
            {
                Descricao = request.Descricao,
                Email = request.Email,
                Fim = request.Fim,
                Inicio = request.Inicio,
                Resumo = request.Resumo
            }, agendaId);
        }

        public async Task<string> DeletarEventoAgendaGoogle(string idEvento, string agendaId)
        {
            return await _service.DeletarEventoAgendaGoogle(idEvento,  agendaId);
        }

        public async Task<Events> ObterDisponibilidade(DateTime datainicio, DateTime datafim, string agendaId)
        {
            return await _service.ObterDisponibilidade(datainicio, datafim, agendaId);
        }

        public async Task<Event> ObterEventoAgendaGoogle(string idEvento, string agendaId)
        {
            return await _service.ObterEventoAgendaGoogle(idEvento, agendaId);
        }

        public async Task<bool> VerificarIndisponibilidade(DateTime inicio, DateTime fim, string agendaId)
        {
            return await _service.VerificarIndisponibilidade(inicio, fim, agendaId);
        }
    }
}
