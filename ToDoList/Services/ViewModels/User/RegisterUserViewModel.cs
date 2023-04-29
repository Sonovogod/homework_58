using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Services.ViewModels.User;

public class RegisterUserViewModel
{
    [Display(Name = "Укажите имя")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 50")]
    [Remote("CheckUniqueName", "UserValidation", ErrorMessage = "Такое имя уже есть", AdditionalFields = "UserName")]
    public string UserName { get; set; }
    
    [Display(Name = "Укажите Email адресс")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [EmailAddress (ErrorMessage = "Некорректный адрес")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Неверный формат ввода")]
    [Remote("CheckUniqueEmail", "UserValidation", ErrorMessage = "Такой адрес уже есть в системе", AdditionalFields = "Email")]
    public string Email { get; set; }
    
    [Display(Name = "Введите пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [MinLength(5, ErrorMessage = "Минимальная длина поля должна быть не менее 5 символов.")]
    public string Password { get; set; }
    
    [Display(Name = "Повторите введенный пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }
}