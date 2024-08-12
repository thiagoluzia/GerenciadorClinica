using GC.Application.CQRS.Commands.Agendamentos.CadastrarAgendamento;
using GC.Application.CQRS.Commands.Agendamentos.DeletarAgendamento;
using GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamento;
using GC.Application.CQRS.Queries.Agendamentos.BuscarAgendamentos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AgendamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new BuscarAgendamentosQuery();
            var agendamento = await _mediator.Send(query);

            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AgendamentoById(int id)
        {
            var query = new BuscarAgendamentoIdQuery(id);
            var agendamento = await _mediator.Send(query);

            if (agendamento is null)
                return NotFound("Agendamento não encontrado");

            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> CriarEvento(AgendamentoCommand command)
        {
            var id = await _mediator.Send(command);

            if (id <= 0)
                return NotFound("Não foi possivel concluir o agendamento");

            return CreatedAtAction(nameof(AgendamentoById), new { id }, command);
        }

        [HttpPut("{id}")]
        private IActionResult EditarEvento(int id, object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEvento(DeletarAgendamentoCommand agendamento, int id)
        {
            if (agendamento.Id != id)
                return BadRequest("Id do objeto diferente do Id a ser deletado");

            var existe = await _mediator.Send(new BuscarAgendamentoIdQuery(id));
            if (existe is null)
                return NotFound("Agendamento não encontrado.");

            await _mediator.Send(agendamento);

            return NoContent();

        }
    }
}
