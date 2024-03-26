using MediatR;

namespace GC.Application.CQRS.Commands.Paciente.DeletarPaciente
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
