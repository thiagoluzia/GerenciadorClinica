using GC.Core.Entityes;
using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Medicos.CadastrarMedico
{
    public  class CadastrarMedicoCommand :  IRequest<int>
    {
        public string? Nome { get;  set; }
        public string? Sobrenome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string? Telefone { get;  set; }
        public string? Email { get;  set; }
        public string? Cpf { get;  set; }
        public ETipoSanguineo TipoSanguineo { get;  set; }
        public Endereco? Endereco { get;  set; }
        public string? Especialidade { get;  set; }
        public string? CRM { get;  set; }
        public string? IdCalendarAgenda { get; set; }

        public CadastrarMedicoCommand(
            string? nome,
            string? sobrenome,
            DateTime dataNascimento,
            string? telefone,
            string? email,
            string? cpf,
            ETipoSanguineo tipoSanguineo,
            Endereco? endereco,
            string? especialidade,
            string? cRM,
            string?
            idCalendarAgenda)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            TipoSanguineo = tipoSanguineo;
            Endereco = endereco;
            Especialidade = especialidade;
            CRM = cRM;
            IdCalendarAgenda = idCalendarAgenda;
        }


    }
}
