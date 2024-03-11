using GC.Application.DTOs.External.ViaCEP;
using GC.Infrastructure.Integrations.ViaCep.Services;

namespace GC.Application.Services.External.ViaCEP
{
    public class ViaCepService : IViaCepService
    {
        private readonly IApiViaCEPService _service;


        public ViaCepService(IApiViaCEPService service)
        {
            _service = service;
        }


        public async Task<EnderecoOutputModel> BuscarEnderecoAsync(string cep)
        {
            var endereco = await _service.ConsultarCepAsync(cep);

            var enderecoOutputModel = new EnderecoOutputModel(
                endereco.Cep
                , endereco.Logradouro
                , endereco.Bairro
                , endereco.Cidade
                , endereco.Uf
                );

            return enderecoOutputModel;
        }
    }
}
