using GC.Core.Entityes;


namespace GC.Core.Repositories
{
    public interface IAgendamentoRepository
    {
        Task<int> Agendar(Agendamento request, string agendaId);
        Task<Agendamento?> AgendamentoById(int id);
        Task<List<Agendamento>> Agendamentos();
        Task<bool> AgendamentoDisponivel(DateTime inicio, DateTime fim, int idMedico);
        Task<int> DeletarAgendamento(int id);
    }
}
