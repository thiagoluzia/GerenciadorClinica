using GC.Application.DTOs.OutputModels;

namespace GC.Application.ExternalServices.ViaCEP
{
    public interface IViaCEPService
    {
        Task<EnderecoOutputMopdel> ConsultarCep(string cep);
    }
}
