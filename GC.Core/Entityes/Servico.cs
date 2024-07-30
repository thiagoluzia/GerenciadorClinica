namespace GC.Core.Entityes
{
    /// <summary>
    /// Representa um serviço oferecido na clínica, como consultas médicas, exames, procedimentos cirúrgicos, etc.
    /// </summary>
    public class Servico : BaseEntity
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Duracao { get; private set; }


        public Servico(string? nome, string? descricao, decimal valor, int duracao)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Duracao = duracao;
        }

        public Servico() { }


        public void Atualizar(string nome, string descricao, decimal valor, int duracao)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Duracao = duracao;
        }
    }
}
