namespace GC.Application.DTOs.External.GoogleCalendar
{
    public class GoogleAgendaInputModel
    {
        public GoogleAgendaInputModel(string email, string resumo, string descricao, DateTime inicio, DateTime fim)
        {
            Email = email;
            Resumo = resumo;
            Descricao = descricao;
            Inicio = inicio;
            Fim = fim;
        }

        public string Email { get; set; }
        public string Resumo { get; set; } // Summary
        public string Descricao { get; set; } // Description
        public DateTime Inicio { get; set; } // Start
        public DateTime Fim { get; set; } // End
    }
}
