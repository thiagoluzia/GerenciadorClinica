using FluentValidation;
using FluentValidation.AspNetCore;
using GC.Application.CQRS;
using GC.Application.Services.External.ViaCEP;
using GC.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace GC.Application.Extensions
{
    /// <summary>
    /// Classe com método de extensão para configuração dos serviços da Application.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Método de extensão pra injeção de dependência da camada de Application.
        /// </summary>
        /// <param name="services">Lista de serviços para a injeção de dependência.</param>
        public static void AddGcApplication(this IServiceCollection services)
        {
            //SERVIÇOS
            services.AddScoped<IViaCepService, ViaCepService>();

            //MEDIATOR
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CQRSContract>());

            //VALIDAÇÕES
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ValidatorContract>();
        }
    }
}



