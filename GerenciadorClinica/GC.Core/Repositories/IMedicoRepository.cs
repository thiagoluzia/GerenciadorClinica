using GC.Core.Entityes;

namespace GC.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<Medico> BuscarMedicoAsync(int id);
        Task<IList<Medico>> BuscarMedicosAsync();
        Task CadastrarMedicoAsync(Medico medico);
        Task AtualizarMedicoAsync(Medico medico);
        Task DeletarMedicoAsync(int id);
    }
}
