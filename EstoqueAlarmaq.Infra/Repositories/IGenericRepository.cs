using System;
using System.Linq;

namespace EstoqueAlarmaq.Infra.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> FindAll();
        TEntity FindById(Guid id);
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Guid id);
    }
}
