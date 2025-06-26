using System.Collections.ObjectModel;
using Task = TaskApp.Models.Task;

namespace TaskApp
{
    public class DataStore
    {
        private static ObservableCollection<Task> _tasks { get; set; }

        public static ObservableCollection<Task> Tasks
        {
            get
            {
                _tasks ??= new();
                return _tasks;
            }
        }

        public static async void Load(ConnectToWeb connectToWeb)
        {
            Console.WriteLine(connectToWeb);
            var taskList = await connectToWeb.GetTasksAsync();
            foreach (var task in taskList)
            {
                Tasks.Add(task);
            }
        }
    }
}
