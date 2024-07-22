using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Medicos.DeletarMedico
{
    public class DeletarMedicoCommandHandler : IRequestHandler<DeletarMedicoCommand, Unit>
    {
        private readonly IMedicoRepository _repository;

        public DeletarMedicoCommandHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletarMedicoCommand request, CancellationToken cancellationToken)
        {

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
