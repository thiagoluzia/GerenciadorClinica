using MediatR;

namespace GC.Application.CQRS.Commands.Pacientes.DeletarPaciente
{
    public  class DeletarPacienteCommand : IRequest<Unit>
    {
        public DeletarPacienteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
