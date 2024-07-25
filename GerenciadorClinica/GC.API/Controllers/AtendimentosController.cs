using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtendimentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok();
        }

        [HttpGet("servico/{id}/data/{data}")]
        public IActionResult GetById(int id, DateTime data)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(object obj)
        {
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
