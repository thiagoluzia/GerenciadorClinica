using MediatR;

namespace GC.Application.CQRS.Commands.Servico.DeletarServico
{
    public class DeletarServicoCommand : IRequest<Unit>
    {
        public DeletarServicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
