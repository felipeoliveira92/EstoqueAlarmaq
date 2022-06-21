using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class ProductObjectRepository : IProductObjectRepository
    {
        private readonly DataContext _context;

        public ProductObjectRepository()
        {
            _context = new DataContext();
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                var product = _context.ProductsObjects.FirstOrDefault(p => p.Id == id);
                _context.ProductsObjects.Remove(product);
                _context.SaveChanges();
            }                
        }

        public List<ProductObject> GetAllProductsObjects()
        {
            return _context.ProductsObjects.ToList();
        }

        public ProductObject GetById(int id)
        {
            if(id != 0)
                return _context.ProductsObjects.Find(id);
            return null;
        }

        public void Insert(ProductObject product)
        {
            _context.ProductsObjects.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, ProductObject product)
        {
            if(id == product.Id)
            {
                _context.ProductsObjects.Update(product);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
