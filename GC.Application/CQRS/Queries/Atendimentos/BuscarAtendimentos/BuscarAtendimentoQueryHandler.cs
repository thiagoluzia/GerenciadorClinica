using GC.Application.DTOs.OutputModels;
using GC.Application.Services.External.GoogleCalendar;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Atendimentos.BuscarAtendimentos
{
    public class BuscarAtendimentoQueryHandler : IRequestHandler<BuscarAtendimentoQuery, List<AtemdimentoOutputModel>>
    {
        private readonly IAtendimentoRepository _repository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IGoogleCalendarService _googleCalendarService;


    
        public BuscarAtendimentoQueryHandler(
            IAtendimentoRepository repository, 
            IMedicoRepository medicoRepository, 
            IGoogleCalendarService googleCalendarService)
        {
            _repository = repository;
            _medicoRepository = medicoRepository;
            _googleCalendarService = googleCalendarService;
        }

        public async Task<List<AtemdimentoOutputModel>> Handle(BuscarAtendimentoQuery request, CancellationToken cancellationToken)
        {
            //var agemda = await _medicoRepository.GetByIdAsync(request.Id)
            

            throw new NotImplementedException();
        }

        //TODO:[] agendamento
        //TODO:[] agendamento - Buscar o id da agenda do medico
        //TODO:[] agendamento - verificar disponibilidade pela agenda
        //TODO:[] agendamento - Gravar na agenda e depois na base de dados com o id do evento


    }
}
