using ToDoList.Enums;

namespace ToDoList.Models;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string Description { get; set; }
    public string Executor { get; set; }
    public TaskStates State { get; set; }
    public bool IsDelete { get; set; }
    public DateTime DateOfCreate { get; set; }
}