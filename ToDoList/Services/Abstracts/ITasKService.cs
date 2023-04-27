using ToDoList.Services.ViewModels;

namespace ToDoList.Services;

public interface ITasKService
{
    public List<ShortTaskViewModel> GetAll();
}