using System.ComponentModel.DataAnnotations;
using ToDoList.Enums;

namespace ToDoList.Services.ViewModels;

public class TaskViewModel
{
    [Display(Name = "Номер")]
    public int Id { get; set; }
    [Display(Name = "Название задачи")]
    public string Title { get; set; }
    [Display(Name = "Приоритет")]
    public PriorityState Priority { get; set; }
    [Display(Name = "Описание")]
    public string Description { get; set; }
    [Display(Name = "Номер")]
    public string? ExecutorId { get; set; }
    public string ManagerId { get; set; }
    public TaskStates States { get; set; }
    public DateTime DateOfCreate { get; set; }
    public DateTime? DateOfOpen { get; set; }
    public DateTime? DateOfClose { get; set; }
}