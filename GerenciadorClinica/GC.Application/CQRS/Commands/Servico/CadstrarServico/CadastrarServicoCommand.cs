using MediatR;

namespace GC.Application.CQRS.Commands.Servico.CadstrarServico
{
    public class CadastrarServicoCommand : IRequest<int>
    {
        public string? Nome { get;  set; }
        public string? Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public int Duracao { get;  set; }
    }
}
