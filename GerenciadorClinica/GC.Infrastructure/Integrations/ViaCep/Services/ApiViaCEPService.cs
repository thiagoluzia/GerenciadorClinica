using GC.Infrastructure.Integrations.ViaCep.Models;
using System.Text.Json;

namespace GC.Infrastructure.Integrations.ViaCep.Services
{
    public class ApiViaCEPService : IApiViaCEPService
    {
        private readonly HttpClient _httpClient;


        public ApiViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ConsultarCepAsync(string cep)
        {
            try
            {
                var rquest = @$"https://viacep.com.br/ws/{cep}/json";
                var response = await _httpClient.GetAsync(rquest);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    var endereco = await JsonSerializer.DeserializeAsync<Endereco>(contentStream);
                    return endereco;
                }
                else
                {
                    throw new Exception("Erro ao consultar o CEP no ViaCEP.");
                }

            }
            catch (JsonException ex)
            {
                throw new JsonException("Erro ao desserializar resposta do ViaCEP.", ex);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException("Erro de desserialização: tipo não suportado.", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Erro de desserialização: argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro desconhecido ao consultar endereço no ViaCEP.", ex);
            }
        }
    }
}
