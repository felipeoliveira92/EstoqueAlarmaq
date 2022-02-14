using EstoqueAlarmaq.Domain;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Application.Interfaces
{
    public interface IProductsRepository
    {
        void Insert(Product product);

        void Update(int id, Product product);

        IEnumerable<Product> SelectAll();

        Product Select(int id);

        void Delete(int id);
    }
}
