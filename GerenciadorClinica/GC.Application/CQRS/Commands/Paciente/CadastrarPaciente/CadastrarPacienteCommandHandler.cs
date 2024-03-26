using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Commands.Paciente.CadastrarPaciente
{
    public class CadastrarPacienteCommandHandler : IRequestHandler<CadastrarPacienteCommand, int>
    {
        private readonly IPacienteRepository _repository;

        public CadastrarPacienteCommandHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<int> Handle(CadastrarPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Core.Entityes.Paciente(
                request.Altura, 
                request.Peso, 
                request.Nome, request.Sobrenome, 
                request.DataNascimento,
                request.Telefone, 
                request.Email, 
                request.Cpf, 
                request.TipoSanguineo, 
                request.Email);


             await _repository.PostAsync(paciente);
            
            return paciente.Id;
        }
    }
}
