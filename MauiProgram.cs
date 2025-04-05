using Microsoft.Extensions.Logging;
using Camera.MAUI;
using CommunityToolkit.Maui;
using datacapture.services;

namespace datacapture
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "datalist.db3");

            
            builder.Services.AddSingleton(s => new DatabaseService(dbPath));
           
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Offlinedata>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
