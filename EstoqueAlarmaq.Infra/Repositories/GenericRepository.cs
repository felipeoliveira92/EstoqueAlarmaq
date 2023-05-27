using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
