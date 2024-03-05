using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    ///Representa um atendimento realizado na clínica a um paciente por um médico.
    /// </summary>
    public class Atendimento : BaseEntity
    {
        public Atendimento(int idPaciente,  int idServico, string? convenio, DateTime inicio, DateTime fim, ETipoAtendimento tipoAtendimento) 
        {
            IdPaciente = idPaciente;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
        }

        public int IdPaciente { get; private set; }
        public Pessoa? NomePaciente { get; private set; }
        public Pessoa? NomeMedico { get; private set; }
        public int IdServico  { get; private set; }
        public Servico? NomeServico { get; private set; }
        public string? Convenio { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public ETipoAtendimento TipoAtendimento { get; private set; }


        public void  Atualizar(int idPaciente, int idServico, string? convenio, DateTime inicio, DateTime fim, ETipoAtendimento tipoAtendimento)
        {
            IdPaciente = idPaciente;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
        }

    }
}
