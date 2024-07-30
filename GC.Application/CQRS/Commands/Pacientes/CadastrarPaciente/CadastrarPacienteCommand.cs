using GC.Core.Entityes;
using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Pacientes.CadastrarPaciente
{
    public  class CadastrarPacienteCommand : IRequest<int>
    {
        public double Altura { get;  set; }
        public double Peso { get;  set; }

        public string? Nome { get;  set; }
        public string? Sobrenome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string? Telefone { get;  set; }
        public string? Email { get;  set; }
        public string? Cpf { get;  set; }
        public ETipoSanguineo TipoSanguineo { get;  set; }
        public Endereco? Endereco { get;  set; }
    }
}
