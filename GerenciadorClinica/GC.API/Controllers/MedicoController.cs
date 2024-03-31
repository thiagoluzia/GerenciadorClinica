using GC.Application.CQRS.Commands.Medico.AtualizarMedico;
using GC.Application.CQRS.Commands.Medico.CadastrarMedico;
using GC.Application.CQRS.Commands.Medico.DeletarMedico;
using GC.Application.CQRS.Commands.Paciente.CadastrarPaciente;
using GC.Application.CQRS.Queries.Medico.BuscarMedico;
using GC.Application.CQRS.Queries.Medico.BuscarMedicos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GC.API.Controllers
{
    ///TODO: [ x ]  Criar controller CRUD
    ///TODO: [ x ]  Criar Entidade core
    ///TODO: [ x ]  Criar DTOs
    ///TODO: [ x ]  Criar Serviços 
    ///TODO: [ x ]  Criar Implemntações do serviço
    ///TODO: [ x ]  Criar contexto
    ///TODO: [ x ]  Criar Filters
    ///TODO: [ x ]  Criar Valitadors
    ///TODO: [ x ]  Registrar Interfaces
    ///TODO: [ x ]  Instalar dependencias (EF, FluentValidation, MediatR, SqlServer)
    ///TODO: [ x ]  Criar Repository
    ///TODO: [ x ]  Criar CQRS 
    ///TODO: [ x ]  Criar controller
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
            //Buscar o medico 
            var query = new BuscarMedicoQuery(id);
            var medico = await _mediator.Send(query);

            //Verificar retorno 
            if (medico is null)
            {
                return NotFound("Médico não encontrado.");
            }

            //Atualizar
            command.Id = medico.Id;
            await _mediator.Send(command);

            //Retornar
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            //converte em query para o mediator
            var query =  new BuscarMedicoQuery(id);

            //buscar com madiator
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
