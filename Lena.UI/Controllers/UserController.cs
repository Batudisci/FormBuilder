using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lena.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/forms");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/forms");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user, string password)
        {
            User accUser = new()
            {
                UserName = user.UserName
            };
            var result = await _userManager.CreateAsync(accUser, password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
