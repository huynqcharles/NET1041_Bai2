using ComplexType.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComplexType.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(user);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
