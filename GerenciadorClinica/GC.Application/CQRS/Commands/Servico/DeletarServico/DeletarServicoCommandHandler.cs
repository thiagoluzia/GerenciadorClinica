using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Application.CQRS.Commands.Servico.DeletarServico
{
    public class DeletarServicoCommandHandler : IRequestHandler<DeletarServicoCommand, Unit>
    {
        public Task<Unit> Handle(DeletarServicoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
