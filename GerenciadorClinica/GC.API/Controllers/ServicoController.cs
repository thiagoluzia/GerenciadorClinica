using GC.Application.CQRS.Commands.Servico.AtualizarServico;
using GC.Application.CQRS.Queries.Servico.BuscarServico;
using GC.Application.CQRS.Queries.Servico.BuscarServicos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicoController(IMediator mediator)
        {
            _mediator = mediator; 
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new BuscarServicosQuery();
            var servico = await _mediator.Send(query);

            if(servico is null)
                return NotFound("Nenhum serviço encontrado.");

            return Ok(servico);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new BuscarServicoQuery(id);

            var servico = await _mediator.Send(query);

            if (servico is null)
                return NotFound("Serviço não encontrado.");

            return Ok(servico); 
        }

        [HttpPost]
        public IActionResult Post(object obj)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,AtualizarServicoCommand command)
        {
            if (id != command.Id)
                return BadRequest("O Id do corpo da requisição não pode ser diferente do Id que deseja atualizar.");

            var query = new BuscarServicoQuery(id);
            var servico = await _mediator.Send(query);

            if (servico is null)
                return NotFound("Serviço não encontrado.");

           
           await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, object obj)
        {
            return Ok();
        }
    }

}
