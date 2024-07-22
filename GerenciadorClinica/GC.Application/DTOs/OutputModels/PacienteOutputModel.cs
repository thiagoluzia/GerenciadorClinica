using GC.Core.Entityes;
using GC.Core.Enums;

namespace GC.Application.DTOs.OutputModels
{
    public class PacienteOutputModel
    {
        public PacienteOutputModel(int id, double altura, double peso, string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, string? cpf, ETipoSanguineo tipoSanguineo, Endereco? endereco)
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

        public int Id { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public ETipoSanguineo TipoSanguineo { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
