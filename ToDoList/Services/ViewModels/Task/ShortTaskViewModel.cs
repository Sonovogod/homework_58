using ToDoList.Enums;

namespace ToDoList.Services.ViewModels;

public class ShortTaskViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PriorityState Priority { get; set; }
    public TaskStates State { get; set; }
    public string ManagerId { get; set; }
    public string? ExecutorId { get; set; }
    public DateTime DateOfCreate { get; set; }
}