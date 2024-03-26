using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Paciente.BuscarPacientes
{
    public class BuscarTodoPacientesQueryHandler : IRequestHandler<BuscarTodoPacientesQuery, List<PacienteOutputModel>>
    {
        private readonly IPacienteRepository _repository;

        public BuscarTodoPacientesQueryHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PacienteOutputModel>> Handle(BuscarTodoPacientesQuery request, CancellationToken cancellationToken)
        {

            var pacientes = await _repository.GetAllAsync();

            if (pacientes is null)
                return null;

            var pacienteOutputModelList = pacientes
                .Select(p => new PacienteOutputModel(
                    p.Id,
                    p.Altura,
                    p.Peso,
                    p.Nome,
                    p.Sobrenome,
                    p.DataNascimento,
                    p.Telefone,
                    p.Email,
                    p.Cpf,
                    p.TipoSanguineo,
                    p.Endereco))
                .ToList();

            return pacienteOutputModelList;
        }
    }
}
