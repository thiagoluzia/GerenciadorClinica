using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Paciente.BuscarPacienteId
{
    public class BuscarPacienteIDQueryHandler : IRequestHandler<BuscarPacienteIDQuery, PacienteOutputModel>
    {
        private readonly IPacienteRepository _repository;

        public BuscarPacienteIDQueryHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }


        public async Task<PacienteOutputModel> Handle(BuscarPacienteIDQuery request, CancellationToken cancellationToken)
        {

            var paciente = await _repository.GetByIdAsync(request.Id);

            if (paciente == null)
                return null;

            var pacienteOutputModel = new PacienteOutputModel(
                paciente.Id,
                paciente.Altura,
                paciente.Peso,
                paciente.Nome,
                paciente.Sobrenome,
                paciente.DataNascimento,
                paciente.Telefone,
                paciente.Email,
                paciente.Cpf,
                paciente.TipoSanguineo,
                paciente.Endereco
                );

            return pacienteOutputModel;

        }
    }
}
