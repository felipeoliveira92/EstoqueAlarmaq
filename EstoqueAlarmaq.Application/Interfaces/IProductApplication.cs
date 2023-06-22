using EstoqueAlarmaq.Application.ViewModels;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Application.Interfaces
{
    public interface IProductApplication
    {
        IEnumerable<ProductViewModel> FindAll();
        bool Create(ProductViewModel model);
    }
}
