using GC.Application.Services.External.ViaCEP;
using GC.Infrastructure.Integrations.ViaCep.Services;

namespace GC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //INTEGRAÇÕES
            builder.Services.AddHttpClient<IApiViaCEPService, ApiViaCEPService>();

            // INJEÇÃO DE DEPENDENCIAS
            builder.Services.AddScoped<IViaCepService, ViaCepService>();


        
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
