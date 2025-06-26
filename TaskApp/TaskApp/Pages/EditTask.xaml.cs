using Task = TaskApp.Models.Task;
namespace TaskApp.Pages;

public partial class EditTask : ContentPage
{
    private int _taskId;
	public EditTask(Task task)
	{
		InitializeComponent();
        _taskId = task.Id;
        TaskName.Text = task.Name;
        TaskDescription.Text = task.Description;
        TaskDate.Date = task.TaskDate.Date;
        Category.Text = task.Category;
        State.IsChecked = task.State;
    }
    private void Clear(object sender, EventArgs e)
    {
        ClearData();
    }

    private void ClearData()
    {
        TaskName.Text = string.Empty;
        TaskDescription.Text = string.Empty;
        PriorityPicker.SelectedIndex = -1;
        Category.Text = string.Empty;
    }
    private void UpdateTask(object sender, EventArgs e)
    {
        Task task = new()
        {
            Name = TaskName.Text,
            Description = TaskDescription.Text,
            Priority = "Medium",
            TaskDate = TaskDate.Date,
            Category = Category.Text,
            State = false
        };
        DataStore.Tasks[_taskId] = task;
        ConnectToWeb.Service.TaskPut(task);
        ClearData();
    }
}