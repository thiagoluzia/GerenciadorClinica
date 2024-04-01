using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Servico.AtualizarServico
{
    public class AtualizarServicoCommandHandler : IRequestHandler<AtualizarServicoCommand, Unit>
    {
        private readonly IServicoRepository _repository;

        public AtualizarServicoCommandHandler(IServicoRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(AtualizarServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Core.Entityes.Servico();
            servico = await _repository.GetByIdAsync(request.Id);

            servico.Atualizar(
                request.Nome,
                request.Descricao,
                request.Valor,
                request.Duracao);

            await _repository.PutAsync(servico);

            return Unit.Value;
        }
    }
}
