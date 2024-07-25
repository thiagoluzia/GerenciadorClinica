using GC.Application.Services.External.ViaCEP;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IViaCepService _service;

        public EnderecosController(IViaCepService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaEndereco(string cep)
        {
            
            if (cep.Length < 8)
            {
                return BadRequest("O cep não pode ser menor que 8 digitos.");
            }

            if (string.IsNullOrEmpty(cep))
            {
                return BadRequest("O cep não pode ser nulo ou vazio.");
            }

            var cepFormatado = FormatarCep(cep);

            var endereco = await _service.BuscarEnderecoAsync(cepFormatado);

            if(endereco.Logradouro is null)
            {
                return NotFound("Endereço não encontrado na base dos correios.");
            }


            return Ok(endereco);
        }

        [HttpGet("ERROR")]
        public async Task<IActionResult> ConsultaEnderecoComException(string cep)
        {
            throw new Exception();
           

            return Ok();
        }

        private string FormatarCep( string cep)
        {
            return  cep.Trim().Replace("-", "").Replace(".", "");
        }
    }
}
