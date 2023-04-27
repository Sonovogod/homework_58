using ToDoList.Enums;

namespace ToDoList.Services.ViewModels;

public class ShortTaskViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PriorityState Priority { get; set; }
    public TaskStates State { get; set; }
}