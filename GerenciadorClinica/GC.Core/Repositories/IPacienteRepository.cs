using GC.Core.Entityes;

namespace GC.Core.Repositories
{
    public interface IPacienteRepository
    {
        Task<IList<Paciente>> GetAllAsync();
        Task<Paciente> GetByCpfOrTelAsync(string cpfOrTel); 
        Task PostAsync(Paciente paciente);
        Task Putasync(Paciente paciente);
        Task DeleteAsync(int id);
        Task<Paciente> GetByIdAsync(int id);
    }
}
