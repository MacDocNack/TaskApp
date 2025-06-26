using Microsoft.Extensions.Logging;

namespace TaskApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ConnectToWeb>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            DataStore.Load(ConnectToWeb.Service);

            return builder.Build();
        }
    }
}
