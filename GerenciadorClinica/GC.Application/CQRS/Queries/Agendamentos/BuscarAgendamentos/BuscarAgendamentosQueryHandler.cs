using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamentos
{
    public class BuscarAgendamentosQueryHandler : IRequestHandler<BuscarAgendamentosQuery, List<AgendamentoOutputModel>>
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

    
        public BuscarAgendamentosQueryHandler(IAgendamentoRepository atendimentoRepository)
        {
            _agendamentoRepository = atendimentoRepository;
        }


        public async Task<List<AgendamentoOutputModel>> Handle(BuscarAgendamentosQuery request, CancellationToken cancellationToken)
        {
            var agendamentos = await _agendamentoRepository.Agendamentos();

            if (agendamentos.Any())
            {
                var agendamentoOutputModel = agendamentos
                    .Select(a => new AgendamentoOutputModel(  
                        a.Id,
                        a.IdPaciente,
                        a.IdMedico,
                        a.IdServico,
                        a.Convenio,
                        a.Inicio,
                        a.Fim,
                        a.TipoAtendimento,
                        a.IdEvento))
                    .ToList();

                return agendamentoOutputModel;
            }

            return null;
        }
    }
}
