using GC.Core.Entityes;

namespace GC.Core.Repositories
{
    public interface IServicoRepository
    {
        Task PostAysnc(Servico servico);
        Task PutAsync(Servico servico);
        Task<Servico> GetByIdAsync(int id);
        Task<List<Servico>> GetAllAsync();
        Task Delete(int id);
    }
}
