using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Servico.BuscarServico
{
    public class BuscarServicoQueryHandler : IRequestHandler<BuscarServicoQuery, ServicoOutputModel>
    {
        private readonly IServicoRepository _repository;

        public BuscarServicoQueryHandler(IServicoRepository repository)
        {
            _repository = repository;
        }


        public async Task<ServicoOutputModel> Handle(BuscarServicoQuery request, CancellationToken cancellationToken)
        {
            var servico = await _repository.GetByIdAsync(request.Id);

            if (servico is null)
                return null;

            var servicoOutputModel = new ServicoOutputModel(
                servico.Id, 
                servico.Nome, 
                servico.Descricao, 
                servico.Valor, 
                servico.Duracao);

            return servicoOutputModel;
        }
    }
}
