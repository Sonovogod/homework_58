using Microsoft.EntityFrameworkCore;
using ToDoList.Enums;
using ToDoList.Extensions;
using ToDoList.Models;
using ToDoList.Services.ViewModels;
using ToDoList.Views.Task;
using ToDoList.Views.Tasks;
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
        List<ShortTaskViewModel> taskViewModels = _db.Tasks
            .Include(x => x.Executor)
            .Include(x => x.Manager)
            .MapToShortTasksViewModels();
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

    public AllTaskPageViewModel GetSortedTask(TaskSortState sortState, int currentPage)
    {
        IQueryable<Task> tasks = _db.Tasks;
        int pageSize = 5;
        int count = tasks.Count();
        
        switch (sortState)
        {
            case TaskSortState.ByTitleAsc:
                tasks = tasks.OrderBy(x => x.Title);
                break;
            case TaskSortState.ByTitleDesk:
                tasks = tasks.OrderByDescending(x => x.Title);
                break;
            case TaskSortState.ByStateAsc:
                tasks = tasks.OrderBy(x => x.State);
                break;
            case TaskSortState.ByStateDesc:
                tasks = tasks.OrderByDescending(x => x.State);
                break;
            case TaskSortState.ByPriorityAsc:
                tasks = tasks.OrderBy(x => x.Priority);
                break;
            case TaskSortState.ByPriorityDesc:
                tasks = tasks.OrderByDescending(x => x.Priority);
                break;
            case TaskSortState.ByDateOfCreateAsc:
                tasks = tasks.OrderBy(x => x.DateOfCreate);
                break;
            case TaskSortState.ByDateOfCreateDesk:
                tasks = tasks.OrderByDescending(x => x.DateOfCreate);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sortState), sortState, null);
        }

        var pagination = tasks.Skip((currentPage - 1) * pageSize).Take(pageSize).MapToShortTasksViewModels();
        AllTaskPageViewModel allTaskPageViewModel = new AllTaskPageViewModel
        {
            Tasks = pagination,
            TitleSort = sortState is TaskSortState.ByTitleAsc ? TaskSortState.ByTitleDesk : TaskSortState.ByTitleAsc,
            DateSort = sortState is TaskSortState.ByDateOfCreateAsc
                ? TaskSortState.ByDateOfCreateDesk
                : TaskSortState.ByDateOfCreateAsc,
            PrioritySort = sortState is TaskSortState.ByPriorityAsc
                ? TaskSortState.ByPriorityDesc
                : TaskSortState.ByPriorityAsc,
            StateSort = sortState is TaskSortState.ByStateAsc ? TaskSortState.ByStateDesc : TaskSortState.ByStateAsc,
            Pagination = new PaginationViewModel(count, currentPage, pageSize)
        };
        return allTaskPageViewModel;
    }
}