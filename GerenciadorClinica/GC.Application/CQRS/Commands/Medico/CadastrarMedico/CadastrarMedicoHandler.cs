﻿using GC.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//Alias na referencia devido a estrutura de pasta do CQRS ter influenciado no entidade
using Entityes = GC.Core.Entityes;

namespace GC.Application.CQRS.Commands.Medico.CadastrarMedico
{
    public class CadastrarMedicoHandler : IRequestHandler<CadastrarMedicoCommand, int>
    {

        private readonly DBClinicaContexto _contexto;

        public CadastrarMedicoHandler(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Handle(CadastrarMedicoCommand request, CancellationToken cancellationToken)
        {
             var medico = new Entityes.Medico(
                request.Nome,
                request.Sobrenome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.Cpf,
                request.TipoSanguineo,
                request.Endereco,
                request.Especialidade,
                request.CRM
                );

            await _contexto.Medico.AddAsync(medico);
            await _contexto.SaveChangesAsync();

            return medico.Id;
          
        }
    }
}
