using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;

namespace ExplorandoMarte.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly List<T> Db;

        protected Repository()
        {
            Db = new List<T>();
        }

        public void Adicionar(T entity)
        {
            Db.Add(entity);
        }
        public void Remover(Guid id)
        {
            Db.Remove(Db.Find(x => x.Id == id));
        }
        public T ObterPorId(Guid id)
        {
            return Db.Find(x => x.Id == id);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
