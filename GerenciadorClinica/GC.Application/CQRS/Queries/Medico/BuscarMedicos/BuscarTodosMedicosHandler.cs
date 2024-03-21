using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using GC.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Application.CQRS.Queries.Medico.BuscarMedicos
{
    public class BuscarTodosMedicosHandler : IRequestHandler<BuscarMedicosQuery, List<MedicoOutputModel>>
    {
        private readonly IMedicoRepository _repository;

        public BuscarTodosMedicosHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MedicoOutputModel>> Handle(BuscarMedicosQuery request, CancellationToken cancellationToken)
        {

            var medicos = await _repository.BuscarMedicosAsync();

            var medicoOutputModel = medicos
                .Select(p => new MedicoOutputModel(
                    p.Id, 
                    p.Nome, 
                    p.Sobrenome, 
                    p.DataNascimento, 
                    p.Telefone,
                    p.Email,
                    p.Cpf,
                    p.TipoSanguineo,
                    p.Endereco,
                    p.Especialidade,
                    p.CRM))
                .ToList();

            return medicoOutputModel;
        }
    }
}
