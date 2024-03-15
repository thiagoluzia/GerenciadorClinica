using GC.Application.DTOs.OutputModels;
using GC.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GC.Application.CQRS.Commands.Medico.AtualizarMedico
{
    public class AtualizarMedicoCommandHandler : IRequestHandler<AtualizarMedicoCommand, Unit>
    {
        private readonly DBClinicaContexto _contexto;

        public AtualizarMedicoCommandHandler(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Unit> Handle(AtualizarMedicoCommand request, CancellationToken cancellationToken)
        {
            //Buscar o medico no banco 
            var medico = await _contexto.Medico.SingleOrDefaultAsync(x => x.Id == request.Id);

            //Atualizar as propriedades pelo metodo medico do core 
            medico.Atualizar(
                request.Nome,
                request.Sobrenome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.Cpf,
                request.TipoSanguineo,
                request.Endereco,
                request.Especialidade,
                request.CRM
                );

            //Atualizar o objeto, alterando o estado no entity
         
            //Salvar no banco de dados
            await _contexto.SaveChangesAsync();

            //Retorna void
            return Unit.Value;
        }
    }
}
