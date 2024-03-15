using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    /// Representa um médico que trabalha na clínica, fornecendo serviços médicos aos pacientes.
    /// </summary>
    public class Medico : BaseEntity
    {
        public Medico()
        { }
        public Medico(
            string nome, 
            string sobrenome, 
            DateTime dataNascimento, 
            string telefone, 
            string email, 
            string cpf, 
            ETipoSanguineo 
            tipoSanguineo, 
            string endereco, 
            string especialidade, 
            string crm)
        {
            Especialidade = especialidade;
            CRM = crm;
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
        public string Especialidade { get; private set; }
        public string CRM { get; private set; }


        public void Atualizar(
            string nome,
            string sobrenome,
            DateTime dataNascimento,
            string telefone,
            string email,
            string cpf,
            ETipoSanguineo tipoSanguineo,
            string endereco,
            string especialidade,
            string crm)
        {

            Especialidade = especialidade;
            CRM = crm;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            TipoSanguineo = tipoSanguineo;
            Endereco = endereco;
        }
    }
}
