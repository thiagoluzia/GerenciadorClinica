using GC.Application.CQRS.Commands.Pacientes.AtualizarPaciente;
using GC.Application.CQRS.Commands.Pacientes.CadastrarPaciente;
using GC.Application.CQRS.Commands.Pacientes.DeletarPaciente;
using GC.Application.CQRS.Queries.Pacientes.BuscarPacienteId;
using GC.Application.CQRS.Queries.Pacientes.BuscarPacientes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new BuscarTodoPacientesQuery();

            var pacientes = await _mediator.Send(query);

            if (pacientes.Count == 0)
                return NotFound("Pacientes não encontrado");

            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest("O id, não pode ser nulo ou zero.");

            var query = new BuscarPacienteIDQuery(id);
            var paciente = await _mediator.Send(query);

            if (paciente is null)
                return NotFound("Paciente não encontrado.");

            return Ok(paciente);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CadastrarPacienteCommand command)
        {
            var id = await _mediator.Send(command);

            if (id == 0)
                return BadRequest();

            return CreatedAtAction(nameof(GetByIdAsync), new { id }, command);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, AtualizarPacienteCommand command)
        {
            if (id != command.Id)
                return BadRequest("O Id do paciente não pode ser diferente do id do paciente que deseja atualizar.");

            var query = new BuscarPacienteIDQuery(id);
            var paciente = await _mediator.Send(query);


            if (paciente is null)
                return NotFound("Paciente não encontrado.");


            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var query = new BuscarPacienteIDQuery(id);

            var existe = await _mediator.Send(query);

            if (existe is null)
                return NotFound("Paciente não encontrado.");

            var comand = new DeletarPacienteCommand(id);
            await _mediator.Send(comand);

            return NoContent();
        }

    }
}
