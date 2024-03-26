﻿using GC.Application.DTOs.OutputModels;
using MediatR;

namespace GC.Application.CQRS.Queries.Paciente.BuscarPacienteId
{
    public class BuscarPacienteIDQuery :IRequest<PacienteOutputModel>
    {
        public BuscarPacienteIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
      
    }
}
