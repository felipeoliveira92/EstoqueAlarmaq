using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Infra.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext dataContext)
        {
            _context = dataContext;
            _dbSet = _context.Set<T>();
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return true;
        }

        public bool CreateRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return true;
        }

        public IEnumerable<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = FindById(id);
            _dbSet.Remove(entity);
            return true;
        }

        public bool DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
