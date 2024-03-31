using MediatR;

namespace GC.Application.CQRS.Commands.Servico.CadstrarServico
{
    public class CadastrarServicoCommandHandler : IRequestHandler<CadastrarServicoCommand, int>
    {
        public Task<int> Handle(CadastrarServicoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
