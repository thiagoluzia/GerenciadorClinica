using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    ///Representa um atendimento realizado na clínica a um paciente por um médico.
    /// </summary>
    public class Atendimento : BaseEntity
    {
        public int IdPaciente { get; private set; }
        public Paciente? NomePaciente { get; private set; }
        public int IdMedico { get; private set; }
        public Medico? NomeMedico { get; private set; }
        public int IdServico  { get; private set; }
        public Servico? NomeServico { get; private set; }
        public string? Convenio { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public ETipoAtendimento TipoAtendimento { get; private set; }
        public string? IdEvento { get; private set; }


        public Atendimento(
            int idPaciente, 
            int idMedico, 
            int idServico, 
            string? convenio, 
            DateTime inicio, 
            DateTime fim, 
            ETipoAtendimento tipoAtendimento, 
            string? idEvento)
        {
            IdPaciente = idPaciente;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
            IdMedico = idMedico;
            IdEvento = idEvento;
        }

        protected Atendimento() { }


        public void  Atualizar(int idPaciente, int idMedico, int idServico, string? convenio, DateTime inicio, DateTime fim, ETipoAtendimento tipoAtendimento, string? IdEvento)
        {
            IdPaciente = idPaciente;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
            IdMedico = idMedico;
            IdEvento = IdEvento;
        }

        public void AtualizarEvento(string idEvento)
        {
            IdEvento = idEvento;
        }
    }
}
