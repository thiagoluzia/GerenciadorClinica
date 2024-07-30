using GC.Application.DTOs.External.GoogleCalendar;
using Google.Apis.Calendar.v3.Data;

namespace GC.Application.Services.External.GoogleCalendar
{
    public interface IGoogleCalendarService
    {
        Task<Event> CriarAgendaGoogle(GoogleAgendaInputModel request, string agendaId);
        Task<bool> VerificarIndisponibilidade(DateTime inicio, DateTime fim, string agendaId);
        Task<FreeBusyResponse> ObterDisponibilidade(DateTime datainicio, DateTime datafim, string agendaId);
        Task<Event> AtualizarEventoAgendaGoogle(string idEvento, GoogleAgendaInputModel request, string agendaId);
        Task<string> DeletarEventoAgendaGoogle(string idEvento, string agendaId);
        Task<Event> ObterEventoAgendaGoogle(string idEvento, string agendaId);
    }
}
