using ToDoList.Models;
using ToDoList.Services.ViewModels;

namespace ToDoList.Services;

public class TaskService : ITasKService
{
    private readonly TaskContext _db;

    public TaskService(TaskContext db)
    {
        _db = db;
    }

    public List<ShortTaskViewModel> GetAll()
    {
        List<ShortTaskViewModel> taskViewModels = _db.Tasks
            .Select(task => new ShortTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Priority = task.Priority,
                State = task.State
            }).ToList();
        return taskViewModels;
    }
}