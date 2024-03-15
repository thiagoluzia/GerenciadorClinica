using GC.Application.DTOs.OutputModels;
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
        private readonly DBClinicaContexto _contexto;

        public BuscarTodosMedicosHandler(DBClinicaContexto context)
        {
            _contexto = context;
        }
        public async Task<List<MedicoOutputModel>> Handle(BuscarMedicosQuery request, CancellationToken cancellationToken)
        {
            var medicos = await _contexto.Medico.ToListAsync();

            var medicoOutputModel = medicos
                .Select(p => new MedicoOutputModel(
                    p.Id, 
                    p.Nome, 
                    p.Sobrenome, 
                    p.DataNascimento, 
                    p.Email, p.Cpf, 
                    p.TipoSanguineo, 
                    p.Endereco, 
                    p.Telefone, 
                    p.Especialidade,
                    p.CRM))
                .ToList();

            return medicoOutputModel;
                
                
        }
    }
}
