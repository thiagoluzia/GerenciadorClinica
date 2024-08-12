using GC.Core.Entityes;
using GC.Core.Enums;

namespace GC.Application.DTOs.OutputModels
{
    public class AgendamentoOutputModel
    {
        public int Id { get; private set; }
        public int IdPaciente { get; private set; }
        public Paciente? Paciente { get; private set; }
        public int IdMedico { get; private set; }
        public Medico? Medico { get; private set; }
        public int IdServico { get; private set; }
        public Servico? Servico { get; private set; }
        public string? Convenio { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public ETipoAtendimento TipoAtendimento { get; private set; }
        public string? IdEvento { get; private set; }

        public AgendamentoOutputModel(
            int id,
            int idPaciente,
            int idMedico,
            int idServico,
            string? convenio,
            DateTime inicio,
            DateTime fim,
            ETipoAtendimento tipoAtendimento,
            string? idEvento)
        {
            Id = id;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
            IdEvento = idEvento;
        }
    }
}
