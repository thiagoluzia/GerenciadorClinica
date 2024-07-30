using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Medicos.BuscarMedico
{
    public class BuscarMedicoQuery : IRequest<MedicoOutputModel>
    {
        public BuscarMedicoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
