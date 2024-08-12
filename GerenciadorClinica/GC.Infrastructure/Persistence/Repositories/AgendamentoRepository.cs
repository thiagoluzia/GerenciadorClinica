using GC.Core.Entityes;
using GC.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GC.Infrastructure.Persistence.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly DBClinicaContexto _contexto;

        public AgendamentoRepository(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<int> Agendar(Agendamento request, string agendaId)
        {

            await _contexto.Agendamentos.AddAsync(request);
            await _contexto.SaveChangesAsync();

            return request.Id;
        }

        public async Task<Agendamento?> AgendamentoById(int id)
        {
            return await _contexto.Agendamentos
                .Include(m => m.Medico)
                .Include(p =>p.Paciente)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Agendamento>> Agendamentos()
        {
            return await _contexto.Agendamentos.ToListAsync();
        }

        public async Task<bool> AgendamentoDisponivel(DateTime inicio, DateTime fim, int idMedico)
        {
            var agendamentos = await _contexto.Agendamentos.ToListAsync();

            foreach (var agendamento in agendamentos)
            {
                if(agendamento.IdMedico == idMedico)
                {
                    var dataInicio = new DateTime(agendamento.Inicio.Year, agendamento.Inicio.Month, agendamento.Inicio.Day, agendamento.Inicio.Hour, agendamento.Inicio.Minute,00);
                    var dataFim = new DateTime(agendamento.Fim.Year, agendamento.Fim.Month, agendamento.Fim.Day, agendamento.Fim.Hour, agendamento.Fim.Minute, 00);

                    var  etdInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, inicio.Hour, inicio.Minute, 00);
                    var etdFim = new DateTime(fim.Year, fim.Month, fim.Day, fim.Hour, fim.Minute, 00);

                    if (dataInicio < etdFim && dataFim >= etdInicio)
                        return false;
                    
                }
            }

            return true;
        }

        public async Task<int> DeletarAgendamento(int id)
        {
            try
            {
                var agendamento = await _contexto.Agendamentos.SingleOrDefaultAsync(a => a.Id == id);

                if (agendamento is not null) 
                { 
                    _contexto.Agendamentos.Remove(agendamento);
                    return await _contexto.SaveChangesAsync();
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
