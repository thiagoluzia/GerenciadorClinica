using GC.Core.Enums;

namespace GC.Core.Entityes
{
    public abstract  class Pessoa : BaseEntity
    {
        /// <summary>
        /// Representa uma pessoa com informações básicas.
        /// </summary>
        /// <param name="nome">O nome da pessoa.</param>
        /// <param name="sobrenome">O sobrenome da pessoa.</param>
        /// <param name="dataNascimento">A data de nascimento da pessoa.</param>
        /// <param name="telefone">O número de telefone da pessoa.</param>
        /// <param name="email">O endereço de e-mail da pessoa.</param>
        /// <param name="cpf">O número do CPF da pessoa.</param>
        /// <param name="tipoSanguineo">O tipo sanguíneo da pessoa.</param>
        /// <param name="endereco">O endereço da pessoa.</param>
        public Pessoa(string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, string? cpf, ETipoSanguineo tipoSanguineo, string? endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            TipoSanguineo = tipoSanguineo;
            Endereco = endereco;
        }


        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public string? Cpf { get; private set; }
        public ETipoSanguineo TipoSanguineo { get; private set; }
        public string? Endereco { get; private set; }


        public virtual  void Atualizar(string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, ETipoSanguineo tipoSanguineo, string? endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            TipoSanguineo = tipoSanguineo;
            Endereco = endereco;
        }

    }
}
