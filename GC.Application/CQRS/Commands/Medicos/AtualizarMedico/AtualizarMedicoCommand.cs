using GC.Core.Entityes;
using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Medicos.AtualizarMedico
{
    public  class AtualizarMedicoCommand :  IRequest<Unit>
    {
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public string? Cpf { get; private set; }
        public ETipoSanguineo TipoSanguineo { get; private set; }
        public Endereco Endereco { get; private set; }
        public string? Especialidade { get; private set; }
        public string? CRM { get; private set; }
        public string? IdCalendarAgenda { get; set; }


        public AtualizarMedicoCommand(
            int id, 
            string? nome,
            string? sobrenome,
            DateTime dataNascimento,
            string? telefone,
            string? email,
            string? cpf,
            ETipoSanguineo tipoSanguineo,
            Endereco endereco,
            string? especialidade,
            string? cRM,
            string? idCalendarAgenda)
        {
            Id = id;
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
