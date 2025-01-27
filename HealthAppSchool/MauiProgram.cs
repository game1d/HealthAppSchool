using CommunityToolkit.Maui;
using HealthAppSchool.Data;
using HealthAppSchool.Pages;
using Microcharts.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;


namespace HealthAppSchool
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddDbContext<DataContext>(
                options => options.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "HealthApp.db")}")
                );
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .UseSkiaSharp()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<HealthAppDatabase>();
            builder.Services.AddTransient<AanmeldPage>();
            return builder.Build();
        }
    }
}
