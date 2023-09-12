using CommunityToolkit.Maui;
using PassBox.Mobile.DataBase;
using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
            .AddSqlite<ApplicationContext>($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PassBox.db")}");

        return builder.Build();
    }
}