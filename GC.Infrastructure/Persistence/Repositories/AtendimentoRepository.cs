using GC.Core.Entityes;
using GC.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GC.Infrastructure.Persistence.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly DBClinicaContexto _contexto;

        public AtendimentoRepository(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<int> Agendar(Atendimento request, string agendaId)
        {

            await _contexto.Atendimento.AddAsync(request);
            await _contexto.SaveChangesAsync();

            return request.Id;
        }
    }
}
