using GC.Application.DTOs.OutputModels;
using GC.Core.Entityes;
using GC.Core.Repositories;
using GC.Infrastructure.Persistence;
using MediatR;
using System.Reflection;

namespace GC.Application.CQRS.Queries.Medicos.BuscarMedico
{
    public class BuscarMedicoQueryHandler : IRequestHandler<BuscarMedicoQuery, MedicoOutputModel>
    {
        private readonly IMedicoRepository _repository;

        public BuscarMedicoQueryHandler(DBClinicaContexto contexto, IMedicoRepository repository)
        {
            _repository = repository;
        }

        public async  Task<MedicoOutputModel> Handle(BuscarMedicoQuery request, CancellationToken cancellationToken)
        {

            var medico = await _repository.GetByIdAsync(request.Id);


            if (medico is null) return null;

            var medicoOutputModel = new MedicoOutputModel
            (
                medico.Id,
                medico.Nome,
                medico.Sobrenome,
                medico.DataNascimento,
                medico.Telefone,
                medico.Email,
                medico.Cpf,
                medico.TipoSanguineo,
                medico.Endereco,
                medico.Especialidade,
                medico.CRM,
                medico.IdCalendarAgenda
             );

            return medicoOutputModel;
        }
    }
}
