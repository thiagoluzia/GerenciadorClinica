namespace GC.Infrastructure.Integrations.GoogleCalendar.Models
{
    public class EventoGoogleAgenda
    {
        public string Email { get; set; }
        public string Resumo { get; set; } // Summary
        public string Descricao { get; set; } // Description
        public DateTime Inicio { get; set; } // Start
        public DateTime Fim { get; set; } // End
    }
}
