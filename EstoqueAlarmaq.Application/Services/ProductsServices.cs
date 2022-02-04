using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application.Services
{
    internal class ProductsServices : IProduct
    {
        //private readonly DataContext _context;
        void IProduct.Delete(Product product, DataContext context)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        void IProduct.Insert(Product product, DataContext context)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        void IProduct.Update(Product product, DataContext context)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
