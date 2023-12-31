using ToDoList.Enums;
using ToDoList.Services.ViewModels;
using ToDoList.Views.Task;
using Task = ToDoList.Models.Task;

namespace ToDoList.Services;

public interface ITasKService
{
    public List<ShortTaskViewModel> GetAll();
    public void Add(CreateTaskViewModel model);
    public Task? GetById(int id);
    public void Update(Task task);
    public void ChangeState(Task task, TaskStates close);
    public AllTaskPageViewModel GetSortedTask(TaskSortState sortState, int currentPage);
}