namespace GC.Core.Entityes
{
    /// <summary>
    /// Classe base para entidades do sistema, contendo informações básicas compartilhadas entre diferentes tipos de entidades.
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
    }
}
