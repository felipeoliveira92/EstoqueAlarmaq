using EstoqueAlarmaq.Infra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OEstoque.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        public UserController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            return Json(users);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UserController/Edit/5
        //[HttpGet]
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(string id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
