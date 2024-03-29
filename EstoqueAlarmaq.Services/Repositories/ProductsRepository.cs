﻿using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository()
        {
            _context = null;
        }

        public Product New()
        {
            return new Product();
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }            
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product Select(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> SelectAll()
        {
            return _context.Products.ToList();
        }

        public void Update(int id, Product product)
        {
            product.Id = id;
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}

