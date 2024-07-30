using GC.Core.Entityes;
using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Atentimentos
{
    public class AtendimentoCommand : IRequest<Unit>
    {
        public AtendimentoCommand(
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
            IdMedico = idMedico;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
            IdEvento = idEvento;
        }

        public int IdPaciente { get; private set; }

        //public Paciente? NomePaciente { get; private set; }
        public int IdMedico { get; private set; }
        //public Medico? NomeMedico { get; private set; }
        public int IdServico { get; private set; }
       //public Servico? NomeServico { get; private set; }
        public string? Convenio { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public ETipoAtendimento TipoAtendimento { get; private set; }
        public string? IdEvento { get; private set; }
    }
}
