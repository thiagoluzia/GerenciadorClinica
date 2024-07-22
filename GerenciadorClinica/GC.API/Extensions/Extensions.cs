using GC.API.Filters;

namespace GC.API.Extensions
{
    /// <summary>
    /// Classe com método de extensão para configuração dos serviços da Infrastructure.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Método de extensão pra injeção de dependência da camada de API.
        /// </summary>
        /// <param name="services">Lista de serviços para a injeção de dependência.</param>
        public static void AddGcApi(this IServiceCollection services)
        {
            //FILTROS
            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

            //SWAGGER
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //API 
            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
        }
    }
}






