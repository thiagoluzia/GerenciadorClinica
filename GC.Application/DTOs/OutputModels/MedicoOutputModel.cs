using GC.Core.Entityes;
using GC.Core.Enums;

namespace GC.Application.DTOs.OutputModels
{
    public class MedicoOutputModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public ETipoSanguineo TipoSanguineo { get; set; }
        public Endereco? Endereco { get; set; }
        public string? Especialidade { get; set; }
        public string? CRM { get; set; }
        public string? IdCalendarAgenda { get; set; }


        public MedicoOutputModel(
            int id,
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
            string? idCalendarAgenda
            )
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
