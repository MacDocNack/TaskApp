using Task = TaskAppWeb.Models.Task;

namespace TaskAppWeb.Interfaces
{
    public interface ITaskRepository
    {
        List<Task> GetAllTasks();
        Task GetTask(int id);
        void Post(Task task);
        void Put(int id, Task task);
        void Delete(int id);
    }
}
