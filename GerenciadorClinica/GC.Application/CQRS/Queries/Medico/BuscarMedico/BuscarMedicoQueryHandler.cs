using GC.Application.DTOs.OutputModels;
using GC.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GC.Application.CQRS.Queries.Medico.BuscarMedico
{
    public class BuscarMedicoQueryHandler : IRequestHandler<BuscarMedicoQuery, MedicoOutputModel>
    {
        private readonly DBClinicaContexto _contexto;

        public BuscarMedicoQueryHandler(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }

        public async  Task<MedicoOutputModel> Handle(BuscarMedicoQuery request, CancellationToken cancellationToken)
        {
            var medico = await _contexto.Medico.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (medico is null) return null;

            var medicoOutputModel = new MedicoOutputModel
            (
                medico.Id,
                medico.Nome,
                medico.Sobrenome,
                medico.DataNascimento,
                medico.Email,
                medico.Cpf,
                medico.TipoSanguineo,
                medico.Endereco,
                medico.Telefone,
                medico.Especialidade,
                medico.CRM

             );

            return medicoOutputModel;
        }
    }
}
