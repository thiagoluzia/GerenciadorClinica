namespace GC.Application.DTOs.External.ViaCEP
{
    public class EnderecoInputModel
    {
        public EnderecoInputModel(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; private set; }

    }
}
