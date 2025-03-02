using ExplorandoMarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(Guid id);
        void Remover(Guid id);
    }
}
