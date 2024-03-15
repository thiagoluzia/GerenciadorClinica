using GC.Application.CQRS.Commands.Medico.AtualizarMedico;
using GC.Application.CQRS.Commands.Medico.CadastrarMedico;
using GC.Application.CQRS.Commands.Medico.DeletarMedico;
using GC.Application.CQRS.Queries.Medico.BuscarMedico;
using GC.Application.CQRS.Queries.Medico.BuscarMedicos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    ///TODO: [ x ]  Criar controller CRUD
    ///TODO: [ x ]  Criar Entidade core
    ///TODO: [ x ]  Criar DTOs
    ///TODO: [ ]  Criar Serviços 
    ///TODO: [ ]  Criar Implemntações do serviço
    ///TODO: [ x ]  Criar contexto
    ///TODO: [ ]  Criar Filters
    ///TODO: [ ]  Criar Valitadors
    ///TODO: [ x ]  Registrar Interfaces
    ///TODO: [ x ]  Instalar dependencias (EF, FluentValidation, MediatR, SqlServer)
    ///TODO: [ ]  Criar Repository
    ///TODO: [ ]  Criar CQRS 
    ///TODO: [ ]  Criar controller
    [ApiController]
    [Route("api/[Controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicoController(IMediator mediator)
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
            {
                return NotFound("Medico não encontrado");
            }
                

            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> PostMedicoAsync([FromBody]CadastrarMedicoCommand command)
        {
           
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdMedicoAsync), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico([FromBody] AtualizarMedicoCommand command, int id)
        {
            //Buscar o medico 
            var query = new BuscarMedicoQuery(id);
            var medico = await _mediator.Send(query);

            //Verificar retorno 
            if (medico is null)
            {
                return NotFound("Médico não encontrado.");
            }

            //Atualizar
            await _mediator.Send(command);

            //Retornar
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var query =  new BuscarMedicoQuery(id);
            var medico = await _mediator.Send(query);


            if (medico is null)
            {
                return NotFound("Médico não encontrado.");
            }
            var deletarMedico = new DeletarMedicoCommand(medico.Id); ;

            await _mediator.Send(deletarMedico);

            return NoContent();
        }
    }
}
