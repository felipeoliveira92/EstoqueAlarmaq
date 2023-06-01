using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Application.ViewModels;
using EstoqueAlarmaq.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application.Repositories
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> FindAll()
        {
            var products =  _productRepository.FindAll();

            var productsViewModel = new List<ProductViewModel>();
            foreach (var item in products)
            {
                productsViewModel.Add(new ProductViewModel
                {
                    Name = item.Name,
                    Amount = item.Amount
                });
            }

            return productsViewModel;
        }
    }
}
