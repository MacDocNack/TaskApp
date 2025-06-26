using System.Threading.Tasks;
using Task = TaskApp.Models.Task;

namespace TaskApp.Pages;

public partial class TaskView : ContentPage
{
    public TaskView()
    {
        InitializeComponent();

        TaskHolder.ItemsSource = DataStore.Tasks;
    }

    private async void ToEditPage(object sender, EventArgs e)
    {
        if (TaskHolder.SelectedItem != null)
            await Navigation.PushAsync(new EditTask(TaskHolder.SelectedItem as Task));
    }

    private async void ToCreatePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTask());
    }

    private async void DeleteTask(object sender, EventArgs e)
    {
        if (TaskHolder.SelectedItem != null)
        {
            bool result = await DisplayAlert("Подтвердить удаление", "Вы уверены, что хотите удалить задачу?", "Да", "Нет");
            if (result)
            {
                ConnectToWeb.Service.TaskDelete(TaskHolder.SelectedItem as Task);
                DataStore.Tasks.Remove(TaskHolder.SelectedItem as Task);
                await DisplayAlert("Уведомление", "Вы удалили задачу", "Ок");
            }
        }
    }
}