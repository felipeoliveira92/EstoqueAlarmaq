using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Infra.Interfaces.Generic
{
    public interface IGenericRepository<T> : IDisposable
    {
        bool Create(T entity);
        bool CreateRange(IEnumerable<T> entities);
        IEnumerable<T> FindAll();
        T FindById(Guid id);
        bool Update(T entity);
        bool Delete(Guid id);
        bool DeleteRange(IEnumerable<T> entities);
    }
}
