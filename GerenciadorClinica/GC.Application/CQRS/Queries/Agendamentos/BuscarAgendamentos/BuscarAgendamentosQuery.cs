using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamentos
{
    public class BuscarAgendamentosQuery : IRequest<List<AgendamentoOutputModel>>{}
}
