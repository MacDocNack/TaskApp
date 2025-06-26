using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace TaskApp.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

    }

    private async void ToTaskView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TaskView());
    }

    private async void ToCreateTask(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateTask());
    }
}