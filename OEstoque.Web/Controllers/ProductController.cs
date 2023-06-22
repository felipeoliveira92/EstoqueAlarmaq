using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Application.ViewModels;
using EstoqueAlarmaq.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstoqueAlarmaq.Services.Repositories;
using EstoqueAlarmaq.Services.DTOs;
using EstoqueAlarmaq.Services.DTOs.SendMail;

namespace OEstoque.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productRepository;

        public ProductController(IProductApplication productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = _productRepository.FindAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_productRepository.Create(model))
                        return RedirectToAction(nameof(Index));
                    else
                        return View(model);
                }
                else
                    return View(model);                
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
