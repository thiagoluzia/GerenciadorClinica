using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Paciente.BuscarPacientes
{
    public  class BuscarTodoPacientesQuery :IRequest<List<PacienteOutputModel>>
    {
    }
}
