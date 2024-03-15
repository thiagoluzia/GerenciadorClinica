using GC.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GC.Application.CQRS.Commands.Medico.DeletarMedico
{
    public class DeletarMedicoCommandHandler : IRequestHandler<DeletarMedicoCommand, Unit>
    {
        private readonly DBClinicaContexto _contexto;

        public DeletarMedicoCommandHandler(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Unit> Handle(DeletarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = await _contexto.Medico.SingleOrDefaultAsync(x => x.Id == request.Id);

            _contexto.Medico.Remove(medico);
            await _contexto.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
