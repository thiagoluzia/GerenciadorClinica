using MediatR;

namespace GC.Application.CQRS.Commands.Servico.AtualizarServico
{
    public class AtualizarServicoCommand : IRequest<Unit>
    {
        public int Id { get;  set; }
        public string? Nome { get;  set; }
        public string? Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public int Duracao { get;  set; }

    }
}
