using APIIClient.IoC;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MAUIAPIConsumer.ViewModels;
using MAUIAPIConsumer.Views;

namespace MAUIAPIConsumer
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

            builder.Services.AddApiClientService(x => x.ApiBaseAddress = "https://localhost:7070");
            
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<UserPage>();
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<MainViewModel>();

            Routing.RegisterRoute(nameof(UserPage),typeof(UserPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
