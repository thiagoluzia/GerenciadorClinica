namespace GC.Application.DTOs.OutputModels
{
    public class ServicoOutputModel
    {
        public ServicoOutputModel(int id, string? nome, string? descricao, decimal valor, int duracao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Duracao = duracao;
        }

        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Duracao { get; private set; }

    }
}
