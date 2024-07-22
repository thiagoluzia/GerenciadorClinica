using GC.Core.Entityes;
using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Pacientes.AtualizarPaciente
{
    public class AtualizarPacienteCommand : IRequest<Unit>
    {
        public AtualizarPacienteCommand(
            int id,
            double altura,
            double peso,
            string? nome,
            string? sobrenome,
            DateTime dataNascimento,
            string? telefone,
            string? email,
            string? cpf,
            ETipoSanguineo
            tipoSanguineo,
            Endereco? endereco)
        {
            Id = id;
            Altura = altura;
            Peso = peso;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            TipoSanguineo = tipoSanguineo;
            Endereco = endereco;
        }

        public int Id { get; private set; }
        public double Altura { get; private set; }
        public double Peso { get; private set; }
        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public string? Cpf { get; private set; }
        public ETipoSanguineo TipoSanguineo { get; private set; }
        public Endereco? Endereco { get; private set; }
    }
}
