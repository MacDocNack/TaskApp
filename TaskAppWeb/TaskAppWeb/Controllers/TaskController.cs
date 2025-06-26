using Microsoft.AspNetCore.Mvc;
using TaskAppWeb.Classes;
using Task = TaskAppWeb.Models.Task;

namespace TaskAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskRepository _taskRepository = new();

        [HttpGet]
        public List<Task> Get()
        {
            return _taskRepository.GetAllTasks();
        }

        [HttpGet("{id}")]
        public Task Get(int id)
        {
            return _taskRepository.GetTask(id);
        }

        [HttpPost]
        public void Post([FromBody] Task task)
        {
            _taskRepository.Post(task);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Task task)
        {
            _taskRepository.Put(id, task);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}
