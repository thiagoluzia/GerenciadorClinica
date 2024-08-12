using GC.Application.DTOs.OutputModels;
using GC.Core.Repositories;
using MediatR;

namespace GC.Application.CQRS.Queries.Medicos.BuscarMedicos
{
    public class BuscarTodosMedicosHandler : IRequestHandler<BuscarMedicosQuery, List<MedicoOutputModel>>
    {
        private readonly IMedicoRepository _repository;


        public BuscarTodosMedicosHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<MedicoOutputModel>> Handle(BuscarMedicosQuery request, CancellationToken cancellationToken)
        {
            var medicos = await _repository.GetAllAsync();

            var medicoOutputModel = medicos
                .Select(p => new MedicoOutputModel(
                    p.Id, 
                    p.Nome, 
                    p.Sobrenome, 
                    p.DataNascimento, 
                    p.Telefone,
                    p.Email,
                    p.Cpf,
                    p.TipoSanguineo,
                    p.Endereco,
                    p.Especialidade,
                    p.CRM,
                    p.IdCalendarAgenda))
                .ToList();

            return medicoOutputModel;
        }
    }
}
