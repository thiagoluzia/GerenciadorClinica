using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamento
{
    public class BuscarAgendamentoIdQuery: IRequest<AgendamentoOutputModel>
    {
        public int Id { get; private set; }

        public BuscarAgendamentoIdQuery(int id)
        {
            Id = id;
        }
    }
}
