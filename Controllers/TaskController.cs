using Microsoft.AspNetCore.Mvc;
using Day_8.Service.TaskService;
using Day_8.Model;
using System.Net;

namespace Day_8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskServices _taskServices;
    public TaskController(ITaskServices taskServices)
    {
        _taskServices = taskServices;
    }

    [HttpGet]
    public IEnumerable<TaskModel> GetAll(){
        return _taskServices.GetAll();
    }
    [HttpPost]
    public HttpStatusCode CreateTask(TaskModel newTask){
        _taskServices.CreateTask(newTask);
        return HttpStatusCode.OK;
    }
    [HttpPut("{id}")]
    public HttpResponseMessage EditTask(int id, TaskModel editedTask) {
        _taskServices.EditTask(id, editedTask);
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
    [HttpGet("{id}")]
    public TaskModel GetById(int id) {
        return _taskServices.GetById(id);
    }
    [HttpDelete("{id}")]
    public HttpStatusCode DeleteById(int id) {
        _taskServices.DeleteById(id);
        return HttpStatusCode.OK;
    }
    [HttpPost("BulkAdd")]
    public HttpStatusCode BulkAdd(List<TaskModel> newTaskList) {
        _taskServices.BulkAdd(newTaskList);
        return HttpStatusCode.OK;
    }
    [HttpPost("BulkDelete")]
    public HttpStatusCode BulkDelete(List<int> deletedTaskIdList) {
        _taskServices.BulkDelete(deletedTaskIdList);
        return HttpStatusCode.OK;
    }
}
