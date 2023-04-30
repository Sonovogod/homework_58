using ToDoList.Services.ViewModels;
using Task = ToDoList.Models.Task;

namespace ToDoList.Extensions;

public static class TaskExtension
{
    public static Task MapToTaskModel(this CreateTaskViewModel model)
    {
        return new Task()
        {
            Title = model.Title,
            Priority = model.Priority,
            Description = model.Description,
            ManagerId = model.ManagerId
        };
    }
    
    public static CreateTaskViewModel MapToCreateTaskViewModel(this Task model)
    {
        return new CreateTaskViewModel()
        {
            Title = model.Title,
            Priority = model.Priority,
            Description = model.Description,
            ManagerId = model.ManagerId
        };
    }
    
    public static TaskViewModel MapToAboutTaskViewModel(this Task model)
    {
        return new TaskViewModel()
        {
            Title = model.Title,
            Priority = model.Priority,
            Description = model.Description,
            ManagerId = model.ManagerId,
            Id = model.Id,
            ExecutorId = model.ExecutorId,
            States = model.State,
            DateOfCreate = model.DateOfCreate,
            DateOfClose = model.DateOfClose,
            DateOfOpen = model.DateOfOpen
        };
    }
    
    public static List<ShortTaskViewModel> MapToShortTasksViewModels (this IEnumerable<Task> model)
    {
        List<ShortTaskViewModel> shortTaskViewModels = model.Select(task => new ShortTaskViewModel
        {
            Id = task.Id,
            Title = task.Title,
            Priority = task.Priority,
            State = task.State,
            ManagerId = task.ManagerId,
            ExecutorId = task.ExecutorId,
            DateOfCreate = task.DateOfCreate
            
        }).ToList();
        return shortTaskViewModels;
    }
}