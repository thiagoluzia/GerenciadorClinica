using GC.Application.DTOs.OutputModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Application.CQRS.Queries.Medico.BuscarMedico
{
    public class BuscarMedicoQuery : IRequest<MedicoOutputModel>
    {
        public BuscarMedicoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
