using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Enums;
using ToDoList.Extensions;
using ToDoList.Services;
using ToDoList.Services.ViewModels;
using Task = ToDoList.Models.Task;

namespace ToDoList.Controllers;

public class TaskController : Controller
{
    private readonly ITasKService _taskService;

    public TaskController(ITasKService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult AllTask()
    {
        List<ShortTaskViewModel> tasks = _taskService.GetAll();
        return View(tasks);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CreateTask()
    {
        CreateTaskViewModel model = new CreateTaskViewModel();
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult CreateTask(CreateTaskViewModel model)
    {
        if (ModelState.IsValid)
        {
            _taskService.Add(model);
            return RedirectToAction("AllTask", "Task");
        }
        return View(model);
    }

    [HttpGet]
    [Authorize]
    public IActionResult AboutTask(int id)
    {
        Task? task = _taskService.GetById(id);
        if (task is not null)
        {
            return View(task.MapToAboutTaskViewModel());
        }

        return NotFound();
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult EditTask(int id)
    {
        Task? task = _taskService.GetById(id);
        if (task is not null)
        {
            var manager = User.Identity.GetUserId().Equals(task.ManagerId);
            var taskState = task.State;
            var isAdmin = User.IsInRole("admin");

            if (isAdmin || (manager && taskState == TaskStates.New))
                return View(task.MapToCreateTaskViewModel());
            
            ModelState.AddModelError(string.Empty, "Можно редактировать только новую задачу или обладать правами администратора");
        }
        else
            return NotFound();

        return RedirectToAction("AboutTask", new { id = task.Id });
    }
    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult EditTask(CreateTaskViewModel model)
    {
        if (ModelState.IsValid)
        {
            Task task = model.MapToTaskModel();
            _taskService.Update(task);
            return RedirectToAction("AboutTask", new { id = task.Id });
        }
        ModelState.AddModelError("Incorrect", "Некорректно введены данные");
        return View(model);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CloseTask(int id)
    {
        Task? task = _taskService.GetById(id);
        if (task is not null)
        {
            _taskService.ChangeState(task, TaskStates.Close);
            return RedirectToAction("AboutTask", new { id = id });
        }

        return NotFound();
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult OpenTask(int id)
    {
        Task? task = _taskService.GetById(id);
        if (task is not null)
        {
            task.ExecutorId = User.Identity.GetUserId();
            _taskService.ChangeState(task, TaskStates.Open);
            return RedirectToAction("AboutTask", new { id = id });
        }

        return NotFound();
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult Delete(int id)
    {
        Task? task = _taskService.GetById(id);
        if (task is not null)
        {
            _taskService.ChangeState(task, TaskStates.Deleted);
            return RedirectToAction("AboutTask", new { id = id });
        }

        return NotFound();
    }
}