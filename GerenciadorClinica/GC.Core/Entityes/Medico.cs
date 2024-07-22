﻿using GC.Core.Enums;

namespace GC.Core.Entityes
{
    /// <summary>
    /// Representa um médico que trabalha na clínica, fornecendo serviços médicos aos pacientes.
    /// </summary>
    public class Medico : Pessoa
    {
        public string? Especialidade { get; private set; }
        public string? CRM { get; private set; }
        public List<Atendimento> Atendimentos { get; private set; }
        public int IdAtendimento { get; private set; }




        public Medico(
            string nome,
            string sobrenome,
            DateTime dataNascimento,
            string telefone,
            string email,
            string cpf,
            ETipoSanguineo
            tipoSanguineo,
            Endereco? endereco,
            string especialidade,
            string crm) : base(nome, sobrenome, dataNascimento, telefone, email, cpf, tipoSanguineo, endereco)
        {
            Especialidade = especialidade;
            CRM = crm;

            Atendimentos = new List<Atendimento>();
        }

        protected Medico() { }


        public  void Atualizar(string? nome, string? sobrenome, DateTime dataNascimento, string? telefone, string? email, ETipoSanguineo tipoSanguineo, Endereco endereco, string especialidade,
            string crm, string cpf)
        {
            base.Atualizar(nome, sobrenome, dataNascimento, telefone, email, tipoSanguineo, endereco, cpf);

            Especialidade = especialidade;
            CRM = crm;

        }

    }
}
