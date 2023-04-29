using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.ViewModels.User;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginUserViewModel{ ReturnUrl = returnUrl });
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            User? user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                    user, model.Password, model.RememberMe, false);

                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("AllTask", "Task");
                }
            }
            ModelState.AddModelError("incorrectAuthentication", "Некорректный логин и/или пароль");
        }
        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserViewModel user)
    {
        if (ModelState.IsValid)
        {
            User newUser = new User
            {
                Email = user.Email,
                UserName = user.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, true);
                return RedirectToAction("AllTask", "Task");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(user);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}