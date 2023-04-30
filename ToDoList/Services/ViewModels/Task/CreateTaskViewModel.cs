using System.ComponentModel.DataAnnotations;
using ToDoList.Enums;

namespace ToDoList.Services.ViewModels;

public class CreateTaskViewModel
{
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Display(Name = "Название задачи")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Минимальное количество знаков: 10, Максимальное - 50")]
    public string Title { get; set; }
    
 
    [Display(Name = "Приоритет задачи")]
    public PriorityState Priority { get; set; }
    public string ManagerId { get; set; }
    
    [Display(Name = "Описание задачи")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Минимальное количество знаков: 10, Максимальное - 500")]
    public string Description { get; set; }
}