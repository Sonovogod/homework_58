using System.ComponentModel.DataAnnotations;

namespace ToDoList.Services.ViewModels.User;

public class LoginUserViewModel
{
    [Display(Name = "Электронный адрес")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Email { get; set; }
    
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}