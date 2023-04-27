using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;
using ToDoList.Services.ViewModels;

namespace ToDoList.Controllers;

public class TaskController : Controller
{
    private readonly ITasKService _service;

    public TaskController(ITasKService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult AllTask()
    {
        List<ShortTaskViewModel> tasks = _service.GetAll();
        return View(tasks);
    }
}