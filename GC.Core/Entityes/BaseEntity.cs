namespace GC.Core.Entityes
{
    /// <summary>
    /// Classe base para entidades do sistema, contendo informações básicas compartilhadas entre diferentes tipos de entidades.
    /// </summary>
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = 0;
        }
        public int Id { get; private set; }
    }
}
