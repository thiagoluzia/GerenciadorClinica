using GC.Core.Repositories;
using GC.Core.Entityes;
using MediatR;

namespace GC.Application.CQRS.Commands.Pacientes.AtualizarPaciente
{

    public class AtualizarPacienteCommandHandler : IRequestHandler<AtualizarPacienteCommand, Unit>
    {

        private readonly IPacienteRepository _repository;

        public AtualizarPacienteCommandHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente(
                request.Altura,
                request.Peso,
                request.Nome, 
                request.Sobrenome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.Cpf,
                request.TipoSanguineo,
                request.Endereco
                );

            await _repository.Putasync(paciente);

            return Unit.Value;
        }
    }
}
