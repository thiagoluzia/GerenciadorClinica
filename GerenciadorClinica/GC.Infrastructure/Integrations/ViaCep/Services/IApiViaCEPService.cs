
using GC.Infrastructure.Integrations.ViaCep.Models;

namespace GC.Infrastructure.Integrations.ViaCep.Services
{
    public interface IApiViaCEPService
    {
        Task<Endereco?> ConsultarCepAsync(string cep);
    }
}
