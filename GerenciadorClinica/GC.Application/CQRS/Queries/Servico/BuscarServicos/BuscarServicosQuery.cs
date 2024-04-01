using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Servico.BuscarServicos
{
    public class BuscarServicosQuery : IRequest<List<ServicoOutputModel>>
    {
    }
}
