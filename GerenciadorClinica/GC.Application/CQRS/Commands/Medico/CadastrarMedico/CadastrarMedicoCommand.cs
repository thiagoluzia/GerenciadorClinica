﻿using GC.Core.Enums;
using MediatR;

namespace GC.Application.CQRS.Commands.Medico.CadastrarMedico
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
        public string? Endereco { get;  set; }
        public string? Especialidade { get;  set; }
        public string? CRM { get;  set; }

    }
}
