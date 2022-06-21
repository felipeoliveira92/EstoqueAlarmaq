using EstoqueAlarmaq.Domain;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface IProductObjectRepository
    {
        void Insert(ProductObject product);

        void Update(int id, ProductObject product);

        List<ProductObject> GetAllProductsObjects();

        ProductObject GetById(int id);

        void Delete(int id);

        void Dispose();
    }
}
