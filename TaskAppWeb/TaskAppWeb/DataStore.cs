using Task = TaskAppWeb.Models.Task;
namespace TaskAppWeb
{
    public static class DataStore
    {
        public static Dictionary<int, Task> Tasks { get; set; }
    }
}
