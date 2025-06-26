using TaskAppWeb.Interfaces;
using Task = TaskAppWeb.Models.Task;

namespace TaskAppWeb.Classes
{
    public class TaskRepository : ITaskRepository
    {
        public List<Task> GetAllTasks()
        {
            return DataStore.Tasks.Values.ToList();
        }

        public Task GetTask(int id)
        {
            DataStore.Tasks.TryGetValue(id, out var task);
            return task;
        }

        public void Post(Task task)
        {
            DataStore.Tasks.Add(task.Id, task);
        }

        public void Put(int id, Task task)
        {
            DataStore.Tasks[id] = task;
        }
        public void Delete(int id)
        {
            DataStore.Tasks.Remove(id);
        }
    }
}
