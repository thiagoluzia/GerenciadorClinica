using GC.Infrastructure.Integrations.GoogleCalendar.Models;
using Google.Apis.Calendar.v3.Data;

namespace GC.Infrastructure.Integrations.GoogleCalendar.Services
{
    public interface IApiGoogleCalendaService
    {
        Task<Event> CriarEventoAgendaGoogle(EventoGoogleAgenda request, string agendaId);
        Task<bool> VerificarIndisponibilidade(DateTime inicio, DateTime fim, string agendaId);
        Task<Events> ObterDisponibilidade(DateTime datainicio, DateTime datafim, string agendaId);
        Task<Event> AtualizarEventoAgendaGoogle(string idEvento, EventoGoogleAgenda request, string agendaId);
        Task<string> DeletarEventoAgendaGoogle(string idEvento, string agendaId);
        Task<Event> ObterEventoAgendaGoogle(string idEvento, string agendaId);
    }
}
