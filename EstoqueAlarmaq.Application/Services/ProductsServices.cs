using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;

namespace EstoqueAlarmaq.Application.Services
{
    public class ProductsServices : IProduct
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
