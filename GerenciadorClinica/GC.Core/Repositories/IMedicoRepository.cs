using GC.Core.Entityes;

namespace GC.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<Medico> GetByIdAsync(int id);
        Task<IList<Medico>> GetAllAsync();
        Task PostAsync(Medico medico);
        Task PutAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
