using System.Globalization;
using Task = TaskApp.Models.Task;

namespace TaskApp.Pages;

public partial class CreateTask : ContentPage
{
    private Random randomId = new Random();
    public CreateTask()
    {
        InitializeComponent();
        PriorityPicker.SelectedIndex = 1;
    }

    // Clear all data in Picker and Entry
    private void Clear(object sender, EventArgs e)
    {
        ClearData();
    }
    // Add task method
    private async void AddTask(object sender, EventArgs e)
    {
        // Get a string from Date and Time Entries to string format {DD:MM:YYYY HH:MM}
        var dateTimeTask = TaskDate.Date + TaskTime.Time;

        // Check Entries
        if (string.IsNullOrWhiteSpace(TaskName.Text))
        {
            await DisplayAlert("Ошибка", "Название задачи обязательно к заполнению.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(dateTimeTask.Date.Date.ToString()))
        {
            await DisplayAlert("Ошибка", "Укажите дату выполнения задачи.", "OK");
            return;
        }

        // Create new Task model with data
        Task task = new()
        {
            Id = randomId.Next(),
            Name = TaskName.Text,
            Description = TaskDescription.Text,
            Priority = PriorityPicker.SelectedItem.ToString(),
            TaskDate = dateTimeTask,
            Category = Category.Text,
            State = false
        };
        try // Try Catch block to add task
        {
            DataStore.Tasks.Add(task);
            ConnectToWeb.Service.TaskPost(task);

            ClearData();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", $"Не удалось сохранить задачу: {ex.Message}", "OK");
        }
    }
    private void ClearData()
    {
        TaskName.Text = string.Empty;
        TaskDescription.Text = string.Empty;
        PriorityPicker.SelectedIndex = 1;
        Category.Text = string.Empty;
    }
}