using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Servicos.DeletarServico
{
    public class DeletarServicoCommandHandler : IRequestHandler<DeletarServicoCommand, Unit>
    {
        private readonly IServicoRepository _repository;


        public DeletarServicoCommandHandler(IServicoRepository repositor)
        {
            _repository = repositor;
        }


        public async Task<Unit> Handle(DeletarServicoCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
