using System.Text.Json.Serialization;

namespace GC.Application.DTOs.OutputModels
{
    public class EnderecoOutputMopdel
    {
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("numero")]
        public string? Numero { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }
    }
}

