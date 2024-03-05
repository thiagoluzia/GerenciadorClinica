using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    /// Representa um paciente que recebe atendimento médico na clínica.
    /// </summary>
    public class Paciente : Pessoa
    {
        public Paciente(double altura, double peso, string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, string? cpf, ETipoSanguineo tipoSanguineo, string? endereco)
            : base(nome, sobrenome, dataNascimento, telefone, email, cpf, tipoSanguineo, endereco)
        {
            Altura = altura;
            Peso = peso;
        }


        public double Altura { get; private set; }
        public double Peso { get; private set; }


        public void Atualizar(double altura, double peso, string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, ETipoSanguineo tipoSanguineo, string? endereco)
        {
            Atualizar(nome, sobrenome, dataNascimento, telefone, email, tipoSanguineo, endereco);

            Altura = altura;
            Peso = peso;
        }
    }
}


