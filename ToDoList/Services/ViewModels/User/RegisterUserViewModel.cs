using System.ComponentModel.DataAnnotations;

namespace ToDoList.Services.ViewModels.User;

public class RegisterUserViewModel
{
    [Display(Name = "Укажите Ваше имя")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string UserName { get; set; }
    
    [Display(Name = "Укажите Email адресс")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Email { get; set; }
    
    [Display(Name = "Введите пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Password { get; set; }
    
    [Display(Name = "Повторите введенный пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string ConfirmPassword { get; set; }
}