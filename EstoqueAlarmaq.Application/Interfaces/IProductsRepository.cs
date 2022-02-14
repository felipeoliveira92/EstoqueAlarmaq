using EstoqueAlarmaq.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
