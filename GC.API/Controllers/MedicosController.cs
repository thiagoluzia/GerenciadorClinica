using GC.Application.CQRS.Commands.Medicos.AtualizarMedico;
using GC.Application.CQRS.Commands.Medicos.CadastrarMedico;
using GC.Application.CQRS.Commands.Medicos.DeletarMedico;
using GC.Application.CQRS.Queries.Medicos.BuscarMedico;
using GC.Application.CQRS.Queries.Medicos.BuscarMedicos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedico()
        {
            var medicoQuery = new BuscarMedicosQuery();

            var medicos = await _mediator.Send(medicoQuery);

            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMedicoAsync(int id)
        {
            var query = new BuscarMedicoQuery(id);

            var medico = await _mediator.Send(query);

            if (medico is null)
                return NotFound("Medico não encontrado");
            
            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> PostMedicoAsync(CadastrarMedicoCommand command)
        {
            var id = await _mediator.Send(command);

            if (id == 0)
                return BadRequest();

            return CreatedAtAction(nameof(GetByIdMedicoAsync), new { id }, command);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(AtualizarMedicoCommand command, int id)
        {
            //converte em query para o mediator e busca com madiator
            var query = new BuscarMedicoQuery(id);
            var medico = await _mediator.Send(query);

            if (medico is null)
                return NotFound("Médico não encontrado.");

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            //converte em query para o mediator e busca com madiator
            var query =  new BuscarMedicoQuery(id);
            var medico = await _mediator.Send(query);

            if (medico is null)
                return NotFound("Médico não encontrado.");
            
            var deletarMedico = new DeletarMedicoCommand(medico.Id); ;

            await _mediator.Send(deletarMedico);

            return NoContent();
        }
    }
}
