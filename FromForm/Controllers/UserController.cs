using FromForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace FromForm.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Countries = new List<string> { "India", "USA", "UK", "Canada" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] UserModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            ViewBag.Countries = new List<string> { "India", "USA", "UK", "Canada" };
            return View(user);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
