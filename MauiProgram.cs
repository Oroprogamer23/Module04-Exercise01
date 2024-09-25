using Microsoft.Extensions.Logging;
using Module0Exercise0.View;
using Module0Exercise0.Services;

namespace Module0Exercise0
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

            //Service
            builder.Services.AddSingleton<IMyservice, MyService>();

            //ContentPage
            builder.Services.AddTransient<LoginPage> ();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
