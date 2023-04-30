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
        return !_userManager.Users.Any(x=> x.UserName != null && x.UserName.ToUpper().Equals(userName.ToUpper()));
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueEmail(string email)
    {
        return !_userManager.Users.Any(x=> x.Email != null && x.Email.ToUpper().Equals(email.ToUpper()));
    }
}