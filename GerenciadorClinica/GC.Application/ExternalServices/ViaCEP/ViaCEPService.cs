using GC.Application.DTOs.OutputModels;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace GC.Application.ExternalServices.ViaCEP
{
    public class ViaCEPService : IViaCEPService
    {
        private readonly HttpClient _httpClient;


        public ViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoOutputMopdel> ConsultarCep(string cep)
        {
            try
            {
                var rquest = @$"https://viacep.com.br/ws/{cep}/json";
                var response = await _httpClient.GetAsync(rquest);

                  if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    var endereco = await JsonSerializer.DeserializeAsync<EnderecoOutputMopdel>(contentStream);
                    return endereco;
                }
                else
                {
                    throw new Exception("Erro ao consultar o CEP no ViaCEP.");
                }

            }
            catch(JsonException ex)
            {
                throw new JsonException("Erro ao desserializar resposta do ViaCEP.", ex);
            }
            catch(NotSupportedException ex)
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
