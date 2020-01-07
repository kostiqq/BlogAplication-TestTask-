using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogAplication.Models;
using Microsoft.AspNetCore.Identity;


namespace BlogAplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private UserContext _context;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, UserContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Неккоректный email и(или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password ");
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect login or password ");
            }
        return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            //clean cookies
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
