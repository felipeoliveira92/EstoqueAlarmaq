using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application
{
    internal interface IProduct 
    {
        void Delete(Product product, DataContext context);
        void Insert(Product product, DataContext context);
        void Update(Product product, DataContext context);
    }
}
