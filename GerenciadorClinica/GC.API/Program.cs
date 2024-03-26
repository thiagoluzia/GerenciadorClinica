using GC.Application.CQRS.Commands.Medico.CadastrarMedico;
using GC.Application.Services.External.ViaCEP;
using GC.Infrastructure.Integrations.ViaCep.Services;
using GC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GC.Application.CQRS;
using GC.Application.Validators;
using GC.API.Filters;
//using FluentValidation.AspNetCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using GC.Core.Repositories;
using GC.Infrastructure.Persistence.Repositories;


namespace GC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //CONTEXTO:
            var connectionString = builder.Configuration.GetConnectionString("DBClinicaCS");
            builder.Services.AddDbContext<DBClinicaContexto>(options =>  options.UseSqlServer(connectionString));

            //INTEGRA합ES
            builder.Services.AddHttpClient<IApiViaCEPService, ApiViaCEPService>();

            // INJE플O DE DEPENDENCIAS
            builder.Services.AddScoped<IViaCepService, ViaCepService>();

            builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
            builder.Services.AddScoped<IPacienteRepository,  PacienteRepository>();

            //MEDIATOR
            //builder.Services.AddMediatR(typeof(CadastrarMedicoCommand));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CQRS>());
           //builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CadastrarMedicoCommand>());


            //FILTROS DE VALIDA합ES
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Validator>();

            //ADICIONAR CONFIGURA플O DE FILTROS E VALIDA합ES
            builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
           
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
