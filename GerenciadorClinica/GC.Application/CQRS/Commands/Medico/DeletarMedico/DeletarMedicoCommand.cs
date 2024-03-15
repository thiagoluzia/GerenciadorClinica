﻿using MediatR;

namespace GC.Application.CQRS.Commands.Medico.DeletarMedico
{
    public class DeletarMedicoCommand : IRequest<Unit>
    {
        public DeletarMedicoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
