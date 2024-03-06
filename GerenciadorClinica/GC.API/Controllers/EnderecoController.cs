using GC.Application.ExternalServices.ViaCEP;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IViaCEPService _service;

        public EnderecoController(IViaCEPService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaEndereco(string cep)
        {
            if (String.IsNullOrEmpty(cep))
            {
                return BadRequest("O cep não pode ser nulo ou vazio.");
            }

            var endereco = await _service.ConsultarCep(cep);

            if(endereco.Logradouro is null)
            {
                return NotFound("Endereço não encontrado na base dos correios.");
            }


            return Ok(endereco);
        }
    }
}
