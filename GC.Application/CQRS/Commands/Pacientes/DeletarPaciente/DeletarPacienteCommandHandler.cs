using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Pacientes.DeletarPaciente
{
    public class DeletarPacienteCommandHandler : IRequestHandler<DeletarPacienteCommand, Unit>
    {
        private readonly IPacienteRepository _repository;

        public DeletarPacienteCommandHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeletarPacienteCommand request, CancellationToken cancellationToken)
        {

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
