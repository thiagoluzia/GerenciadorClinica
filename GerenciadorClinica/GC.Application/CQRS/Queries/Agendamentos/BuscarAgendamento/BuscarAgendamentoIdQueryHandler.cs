using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamento
{
    public class BuscarAgendamentoIdQueryHandler : IRequestHandler<BuscarAgendamentoIdQuery, AgendamentoOutputModel>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;


        public BuscarAgendamentoIdQueryHandler(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }


        public async Task<AgendamentoOutputModel> Handle(BuscarAgendamentoIdQuery request, CancellationToken cancellationToken)
        {
            var agendamento = await _agendamentoRepository.AgendamentoById(request.Id);

            if (agendamento is null)
                return default;

            var agendamentoOutpuModel = new AgendamentoOutputModel(
                agendamento.Id,
                agendamento.IdPaciente,
                agendamento.IdMedico,
                agendamento.IdServico,
                agendamento.Convenio,
                agendamento.Inicio,
                agendamento.Fim,
                agendamento.TipoAtendimento,
                agendamento.IdEvento
                );

            return agendamentoOutpuModel;
        }
    }
}
