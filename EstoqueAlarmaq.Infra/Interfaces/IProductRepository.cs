using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

    }
}
