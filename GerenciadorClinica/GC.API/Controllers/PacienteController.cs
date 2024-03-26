using GC.Application.CQRS.Commands.Medico.DeletarMedico;
using GC.Application.CQRS.Commands.Paciente.AtualizarPaciente;
using GC.Application.CQRS.Commands.Paciente.CadastrarPaciente;
using GC.Application.CQRS.Commands.Paciente.DeletarPaciente;
using GC.Application.CQRS.Queries.Medico.BuscarMedico;
using GC.Application.CQRS.Queries.Paciente.BuscarPacienteId;
using GC.Application.CQRS.Queries.Paciente.BuscarPacientes;
using GC.Application.DTOs.OutputModels;
using GC.Core.Entityes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var query = new BuscarTodoPacientesQuery();

            var pacientes = await _mediator.Send(query);

            if (pacientes.Count == 0)
                return NotFound("Pacientes não encontrado");

            return Ok(pacientes);
        }

        //[HttpGet("{cpfOrTel}")]
        //public IActionResult GetByCpf(string cpfOrTel)
        //{
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> PostAsyn(CadastrarPacienteCommand command)
        {
            var id = await _mediator.Send(command);

            if (id == 0)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AtualizarPacienteCommand command)
        {
            if (id != command.Id)
                return BadRequest("O Id do paciente não pode ser diferente do id do paciente que deseja atualizar.");

            var query = new BuscarPacienteIDQuery(id);
            var paciente = await _mediator.Send(query);


            if (paciente is null)
                return NotFound("Paciente não encontrado.");


            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
