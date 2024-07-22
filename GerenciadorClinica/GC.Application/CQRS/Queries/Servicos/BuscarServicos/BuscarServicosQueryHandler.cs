using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Servicos.BuscarServicos
{
    public class BuscarServicosQueryHandler : IRequestHandler<BuscarServicosQuery, List<ServicoOutputModel>>
    {
        private readonly IServicoRepository _repository;


        public BuscarServicosQueryHandler(IServicoRepository repository)
        {
            _repository = repository;   
        }


        public async Task<List<ServicoOutputModel>> Handle(BuscarServicosQuery request, CancellationToken cancellationToken)
        {
            var servico = await _repository.GetAllAsync();

            var servicoOutputModel =  servico
                .Select(x => new ServicoOutputModel(
                    x.Id,
                    x.Nome,
                    x.Descricao,
                    x.Valor
                    , x.Duracao
                    )).ToList();

            return servicoOutputModel;
        }
    }
}
