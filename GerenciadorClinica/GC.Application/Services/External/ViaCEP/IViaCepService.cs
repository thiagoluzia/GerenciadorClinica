using GC.Application.DTOs.External.ViaCEP;

namespace GC.Application.Services.External.ViaCEP
{
    public interface IViaCepService
    {
        Task<EnderecoOutputModel> BuscarEnderecoAsync(string cep);
    }
}
