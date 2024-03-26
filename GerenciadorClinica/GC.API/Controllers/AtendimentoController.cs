using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtendimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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
