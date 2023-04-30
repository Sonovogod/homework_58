using ToDoList.Enums;
using ToDoList.Extensions;
using ToDoList.Models;
using ToDoList.Services.ViewModels;
using Task = ToDoList.Models.Task;

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
        List<ShortTaskViewModel> taskViewModels = _db.Tasks.MapToShortTasksViewModels();
        return taskViewModels;
    }

    public void Add(CreateTaskViewModel model)
    {
        Task task = model.MapToTaskModel();
        task.State = TaskStates.New;
        task.DateOfCreate = DateTime.Now;
        _db.Tasks.Add(task);
        _db.SaveChanges();
    }

    public Task? GetById(int id)
        => _db.Tasks.FirstOrDefault(x => x.Id == id);

    public void Update(Task task)
    {
        _db.Tasks.Update(task);
        _db.SaveChanges();
    }

    public void ChangeState(Task task, TaskStates state)
    {
        task.State = state;
        switch (state)
        {
            case TaskStates.Close:
                task.DateOfClose = DateTime.Now;
                break;
            case TaskStates.Open:
                task.DateOfOpen = DateTime.Now;
                break;
        }
        Update(task);
    }
}