using GC.Core.Repositories;
using GC.Infrastructure.Integrations.GoogleCalendar.Services;
using GC.Infrastructure.Integrations.ViaCep.Services;
using GC.Infrastructure.Persistence;
using GC.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GC.Infrastructure.Extensions
{
    /// <summary>
    /// Classe com método de extensão para configuração dos serviços da Infrastructure.
    /// </summary>
    public static class Extencions
    {
        /// <summary>
        /// Método de extensão pra injeção de dependência da camada de Infrastructure.
        /// </summary>
        /// <param name="services">Lista de serviços para a injeção de dependência.</param>
        /// <param name="connectionString">String de conexão.</param>
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            //DB
            services.AddDbContext<DBClinicaContexto>(options => options.UseSqlServer(connectionString));

            //SERVIÇOS
            services.AddHttpClient<IApiViaCEPService, ApiViaCEPService>();
            services.AddHttpClient<IApiGoogleCalendaService, ApiGoogleCalendarService>();

            //REPOSITORIES
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
        }
    }
}
