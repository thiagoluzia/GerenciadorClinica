using GC.Core.Repositories;
using MediatR;

//Alias na referencia devido a estrutura de pasta do CQRS ter influenciado no entidade
using Entityes = GC.Core.Entityes;

namespace GC.Application.CQRS.Commands.Medico.CadastrarMedico
{
    public class CadastrarMedicoHandler : IRequestHandler<CadastrarMedicoCommand, int>
    {

        private readonly IMedicoRepository _repository;

        public CadastrarMedicoHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CadastrarMedicoCommand request, CancellationToken cancellationToken)
        {

             var medico = new Entityes.Medico(
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

            await _repository.CadastrarMedicoAsync(medico);

            return medico.Id;
          
        }
    }
}
