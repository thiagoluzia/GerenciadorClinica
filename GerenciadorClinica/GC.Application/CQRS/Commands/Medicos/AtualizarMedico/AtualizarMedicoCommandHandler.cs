using GC.Core.Entityes;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Medicos.AtualizarMedico
{
    public class AtualizarMedicoCommandHandler : IRequestHandler<AtualizarMedicoCommand, Unit>
    {
        private readonly IMedicoRepository _repositoty;

        public AtualizarMedicoCommandHandler(IMedicoRepository repositoty)
        {
            _repositoty = repositoty;
        }

        public async Task<Unit> Handle(AtualizarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = await _repositoty.GetByIdAsync(request.Id);

            //Atualizar as propriedades pelo metodo medico do core 
            medico.Atualizar(
                request.Nome,
                request.Sobrenome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.TipoSanguineo,
                request.Endereco,
                request.Especialidade,
                request.CRM,
                request.Cpf

                );


            //Salvar no banco de dados
            await _repositoty.PutAsync(medico);

            //Retorna void
            return Unit.Value;
        }
    }
}
