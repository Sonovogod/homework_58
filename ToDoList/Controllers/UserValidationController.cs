using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class UserValidationController : Controller
{
    private readonly UserManager<User> _userManager;

    public UserValidationController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName(string userName)
    {
        return !_userManager.Users.Any(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(userName.Normalize()));
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueEmail(string email)
    {
        return !_userManager.Users.Any(x=> x.NormalizedEmail != null && x.NormalizedEmail.Equals(email.Normalize()));
    }
}