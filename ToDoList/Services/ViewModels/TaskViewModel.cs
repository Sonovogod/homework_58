using ToDoList.Enums;

namespace ToDoList.Services.ViewModels;

public class TaskViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string Description { get; set; }
    public string Executor { get; set; }
    public TaskStates States { get; set; }
    public bool IsDelete { get; set; }
    public DateTime DateOfCreate { get; set; }
}