namespace GC.Application.DTOs.External.ViaCEP
{
    public class EnderecoOutputModel
    {
        public EnderecoOutputModel(string? cep, string? logradouro, string? bairro,string? cidade, string? uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }

        public string? Cep { get; private set; }
        public string? Logradouro { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Uf { get; private set; }

    }
}
