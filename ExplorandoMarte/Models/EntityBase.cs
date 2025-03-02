namespace ExplorandoMarte.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        protected EntityBase()
        {
            //Id = Guid.NewGuid();
        }
    }
}