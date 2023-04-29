using ToDoList.Enums;

namespace ToDoList.Models;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PriorityState Priority { get; set; }
    public string Description { get; set; }
    public string? ExecutorId { get; set; }
    public User Executor { get; set; }
    public string ManagerId { get; set; }
    public User Manager { get; set; }
    public TaskStates State { get; set; }
    public DateTime? DateOfOpen { get; set; }
    public DateTime? DateOfClose { get; set; }
    public DateTime DateOfCreate { get; set; }
}