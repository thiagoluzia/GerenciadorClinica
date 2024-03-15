using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Medico.AtualizarMedico
{
    public  class AtualizarMedicoCommand :  IRequest<Unit>
    {
  
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public ETipoSanguineo TipoSanguineo { get; set; }
        public string? Endereco { get; set; }
        public string? Especialidade { get; set; }
        public string? CRM { get; set; }


    }
}
