using GC.Infrastructure.Integrations.GoogleCalendar.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using NodaTime.Extensions;


namespace GC.Infrastructure.Integrations.GoogleCalendar.Services
{
    public class ApiGoogleCalendarService : IApiGoogleCalendaService
    {

        private readonly HttpClient _httpClient;
        private const string TIMEZONE = "America/Sao_Paulo";
        private const string EMAIL_AGENDAMENTO = "EMAIL DA CLINICA PRA GERIR AS AGENDAS";

        public ApiGoogleCalendarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private static async Task<CalendarService> ConectarAgendaGoogle(string[] escopos)
        {
            string nomeAplicacao = "Integracao Google Calendar";
            UserCredential credencial;


            // Obtém o diretório de trabalho atual (normalmente o diretório do projeto API)
            string diretorioAtual = Directory.GetCurrentDirectory();

            // Constrói o caminho relativo para a camada de Infraestrutura
            string localRelativo = Path.Combine(diretorioAtual, "..", "GC.Infrastructure\\Integrations\\GoogleCalendar\\Credential");
            string caminhoCompleto = Path.GetFullPath(localRelativo);



            using (var stream = new FileStream(Path.Combine(caminhoCompleto, "credential.json"), FileMode.Open, FileAccess.Read))
            {
                string caminhoCredencial = "token.json";
                credencial = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        escopos,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(caminhoCredencial, true)
                );
            }

            var servicos = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credencial,
                ApplicationName = nomeAplicacao
            });

            return servicos;
        }

        public async Task<Event> CriarEventoAgendaGoogle(EventoGoogleAgenda evento, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar" };
            var servicos = await ConectarAgendaGoogle(escopos);


            Event eventoAgenda = new Event()
            {
                Summary = evento.Resumo,
                Start = new EventDateTime
                {
                    DateTimeDateTimeOffset = evento.Inicio.AddHours(3),
                    TimeZone = TIMEZONE
                },

                End = new EventDateTime
                {
                    DateTimeDateTimeOffset = evento.Fim.AddHours(3),
                    TimeZone = TIMEZONE
                },
                Description = evento.Descricao,
                Organizer = new Event.OrganizerData
                {
                    Email = EMAIL_AGENDAMENTO,
                    //DisplayName = "Paciente"
                },
                Attendees = new List<EventAttendee>
                {
                    new EventAttendee { Email = evento.Email }
                },
                Reminders = new Event.RemindersData
                {
                    UseDefault = false,
                    Overrides = new List<EventReminder>
                    {
                        new EventReminder { Method = "email", Minutes = 10 }
                    }
                }
            };

            var request = servicos.Events.Insert(eventoAgenda, agendaId);
            request.SendUpdates = EventsResource.InsertRequest.SendUpdatesEnum.All; // Garante o envio dos convites


            return await request.ExecuteAsync();

        }

        public async Task<IList<Event>> ObterEventosAgendaGoogle(string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar.readonly" };
            var servicos = await ConectarAgendaGoogle(escopos);

            var eventos = await servicos.Events.List(agendaId).ExecuteAsync();

            return eventos.Items;
        }

        public async Task<Event> ObterEventoAgendaGoogle(string idEvento, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar.readonly" };
            var servicos = await ConectarAgendaGoogle(escopos);

            var evento = await servicos.Events.Get(agendaId, idEvento).ExecuteAsync();

            return evento;
        }

        public async Task<string> DeletarEventoAgendaGoogle(string idEvento, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar" };
            var servicos = await ConectarAgendaGoogle(escopos);

            var evento = await servicos.Events.Delete(agendaId, idEvento).ExecuteAsync();
            return evento;
        }

        public async Task<Event> AtualizarEventoAgendaGoogle(string idEvento, EventoGoogleAgenda request, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar" };
            var servicos = await ConectarAgendaGoogle(escopos);

            Event eventoAgenda = new Event()
            {
                Summary = request.Resumo,
                Start = new EventDateTime
                {
                    DateTime = request.Inicio.ToUniversalTime(), // Convertendo para UTC
                    TimeZone = "America/Sao_Paulo",

                },
                End = new EventDateTime
                {
                    DateTime = request.Fim.ToUniversalTime(), // Convertendo para UTC
                    TimeZone = "America/Sao_Paulo"
                },
                Description = request.Descricao
            };

            var evento = await servicos.Events.Update(eventoAgenda, agendaId, idEvento).ExecuteAsync();

            return evento;
        }

        public async Task<Events> ObterDisponibilidade(DateTime datainicio, DateTime datafim, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar.readonly" };
            var servicos = await ConectarAgendaGoogle(escopos);
    
            var eventoList = await servicos.Events.List(agendaId).ExecuteAsync();

            return eventoList;
        }

        public async Task<bool> VerificarIndisponibilidade(DateTime inicio, DateTime fim, string agendaId)
        {
            var eventoList = await ObterDisponibilidade(inicio, fim, agendaId);


            // Verifica se há sobreposição
            foreach (var item in eventoList.Items)
            {
                if (inicio < item.End.DateTimeDateTimeOffset && fim > item.Start.DateTimeDateTimeOffset)
                    return true; // Encontrou uma sobreposição
            }

            return false; // Não encontrou sobreposição
        }

    }
}

