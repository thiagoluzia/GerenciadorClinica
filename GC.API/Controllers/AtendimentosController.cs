using GC.Application.CQRS.Commands.Atentimentos;
using GC.Application.DTOs.External.GoogleCalendar;
using GC.Application.Services.External.GoogleCalendar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGoogleCalendarService _service;

        public AtendimentosController(IMediator mediator, IGoogleCalendarService service)
        {
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            //var atendimentos = await _mediator.Send( new BuscarAtendimentosQuery());
            return Ok();
        }

        [HttpGet("servico/{id}/data/{data}")]
        public IActionResult GetById(int id, DateTime data)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Agendar(AtendimentoCommand command)
        {

            var atendimento = await _mediator.Send(command);
            
            //if (AtendimentoCommand == null)
            //    return BadRequest("Evento não pode ser nulo ou vazio.");

            if (atendimento is { })
                return BadRequest("Atendimento não pode ser nulo ou vazio.");

            //var ok = await _service.CriarAgendaGoogle(evento);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Post(int id, object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, object obj)
        {
            return Ok();
        }
    }
}
