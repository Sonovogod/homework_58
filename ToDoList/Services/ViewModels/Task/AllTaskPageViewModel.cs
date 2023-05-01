using ToDoList.Enums;
using ToDoList.Services.ViewModels;
using ToDoList.Views.Tasks;

namespace ToDoList.Views.Task;

public class AllTaskPageViewModel
{
    public List<ShortTaskViewModel> Tasks { get; set; }
    public TaskSortState TitleSort { get; set; }
    public TaskSortState PrioritySort { get; set; }
    public TaskSortState StateSort { get; set; }
    public TaskSortState DateSort { get; set; }
    public PaginationViewModel Pagination { get; set; }
}