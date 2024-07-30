using GC.Infrastructure.Integrations.GoogleCalendar.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Reflection.Metadata;
using NodaTime;
using NodaTime.TimeZones;
using System;


namespace GC.Infrastructure.Integrations.GoogleCalendar.Services
{
    public class ApiGoogleCalendarService : IApiGoogleCalendaService
    {
        
        private readonly HttpClient _httpClient;

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

        public async Task<Event> CriarAgendaGoogle(GoogleAgenda request, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar" };
            var servicos = await ConectarAgendaGoogle(escopos);



            Event eventoAgenda = new Event()
            {
                Summary = request.Resumo,
                Start = new EventDateTime
                {
                    //DateTimeRaw = request.Inicio.ToString(),
                    DateTimeDateTimeOffset = request.Inicio.AddHours(3),
                    //DateTime = request.Inicio,
                    TimeZone = "America/Sao_Paulo"
                },

                End = new EventDateTime
                {
                    //DateTimeRaw = request.Fim.ToString(),
                    DateTimeDateTimeOffset = request.Fim.AddHours(3),
                    //DateTime = request.Fim,
                    TimeZone = "America/Sao_Paulo"
                },
                Description = request.Descricao,
                Organizer = new Event.OrganizerData
                {
                    Email = "thiago.mouraluzia@gmail.com",
                    DisplayName = "Paciente"
                },
                Attendees = new List<EventAttendee>
                {
                    new EventAttendee { Email = request.Email }
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

            var requisicaoEvento = servicos.Events.Insert(eventoAgenda, agendaId);
            requisicaoEvento.SendUpdates = EventsResource.InsertRequest.SendUpdatesEnum.All; // Garante o envio dos convites


            var requisicaoCriacao = await requisicaoEvento.ExecuteAsync();

            return requisicaoCriacao;
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

        public async Task<Event> AtualizarEventoAgendaGoogle(string idEvento, GoogleAgenda request,string agendaId)
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

        public async Task<FreeBusyResponse> ObterDisponibilidade(DateTime datainicio, DateTime datafim, string agendaId)
        {
            string[] escopos = { "https://www.googleapis.com/auth/calendar.readonly" };
            var servicos = await ConectarAgendaGoogle(escopos);

            FreeBusyRequest requisicaoDisponibilidade = new FreeBusyRequest
            {
                TimeMin = datainicio,
                TimeMax = datafim,
                TimeZone = "America/Sao_Paulo",
                Items = new List<FreeBusyRequestItem>
                {
                    new FreeBusyRequestItem { Id = agendaId }
                }
            };

            var requisicao = servicos.Freebusy.Query(requisicaoDisponibilidade);
            FreeBusyResponse resposta = await requisicao.ExecuteAsync();

            return resposta;
        }

        public async Task<bool> VerificarIndisponibilidade(DateTime inicio, DateTime fim, string agendaId)
        {
            var disponibilidade = await ObterDisponibilidade(inicio, fim,agendaId);
            var horariosOcupados = disponibilidade.Calendars[agendaId].Busy;

            foreach (var ocupado in horariosOcupados)
            {
                // Verifica se há sobreposição
                if (inicio < ocupado.End && fim > ocupado.Start)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

