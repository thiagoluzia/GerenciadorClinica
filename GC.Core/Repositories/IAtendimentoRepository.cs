using GC.Core.Entityes;
using Google.Apis.Calendar.v3.Data;


namespace GC.Core.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<int> Agendar(Atendimento request, string agendaId);


    }
}
