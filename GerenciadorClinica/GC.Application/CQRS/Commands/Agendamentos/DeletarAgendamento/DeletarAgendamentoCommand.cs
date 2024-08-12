using MediatR;

namespace GC.Application.CQRS.Commands.Agendamentos.DeletarAgendamento
{
    public  class DeletarAgendamentoCommand :IRequest<Unit>
    {
        public int Id { get; private set; }

        
        public DeletarAgendamentoCommand(int id)
        {
            Id = id;
        }

    }
}
