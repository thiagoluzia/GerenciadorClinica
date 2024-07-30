using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Atendimentos.BuscarAtendimentos
{
    public class BuscarAtendimentoQuery : IRequest<List<AtemdimentoOutputModel>>
    {
        public BuscarAtendimentoQuery(int id)
        {
            Id = id;
        }


        public int Id { get; set; }
    }
}
