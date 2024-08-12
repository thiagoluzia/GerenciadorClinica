using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Servicos.BuscarServico
{
    public class BuscarServicoQuery:IRequest<ServicoOutputModel>
    {
        public int Id { get; set; }


        public BuscarServicoQuery(int id)
        {
            Id = id;
        }
    }
}
