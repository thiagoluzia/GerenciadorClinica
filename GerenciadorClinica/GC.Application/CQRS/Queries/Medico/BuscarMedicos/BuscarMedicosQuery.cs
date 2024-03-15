using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Medico.BuscarMedicos
{
    public class BuscarMedicosQuery : IRequest<List<MedicoOutputModel>>
    {
        public int Id { get; private set; }
        public BuscarMedicosQuery()
        {
            Id = 0;
        }
    }
}
