using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;

namespace EstoqueAlarmaq.Application
{
    public interface IProduct 
    {
        void Delete(Product product, DataContext context);
        void Insert(Product product, DataContext context);
        void Update(Product product, DataContext context);
    }
}
