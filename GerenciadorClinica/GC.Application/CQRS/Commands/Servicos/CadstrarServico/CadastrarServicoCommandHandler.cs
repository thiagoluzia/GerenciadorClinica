using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Servicos.CadstrarServico
{
    public class CadastrarServicoCommandHandler : IRequestHandler<CadastrarServicoCommand, int>
    {
        private readonly IServicoRepository _repository;


        public CadastrarServicoCommandHandler(IServicoRepository repository)
        {
            _repository = repository;
        }


        public async Task<int> Handle(CadastrarServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Core.Entityes.Servico(
                request.Nome,
                request.Descricao,
                request.Valor,
                request.Duracao
                );

            await _repository.PostAysnc(servico);

            return servico.Id;

        }
    }
}
