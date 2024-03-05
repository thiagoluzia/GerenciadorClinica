using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    /// Representa um médico que trabalha na clínica, fornecendo serviços médicos aos pacientes.
    /// </summary>
    public class Medico : Pessoa
    {
        public Medico(string nome, string sobrenome, DateTime dataNascimento, string telefone, string email, string cpf, ETipoSanguineo tipoSanguineo, string endereco, string especialidade, string crm)
            : base(nome, sobrenome, dataNascimento, telefone, email, cpf, tipoSanguineo, endereco)
        {
            Especialidade = especialidade;
            CRM = crm;
        }


        public string Especialidade { get; private set; }
        public string CRM { get; private set; }


        public void Atualizar(string nome, string sobrenome, DateTime dataNascimento, string telefone, string email, string cpf, ETipoSanguineo tipoSanguineo, string endereco, string especialidade, string crm) 
        {
            Atualizar(nome, sobrenome, dataNascimento, telefone, email, tipoSanguineo, endereco);
            
            Especialidade = especialidade;
            CRM = crm;
        }

    }
}
 