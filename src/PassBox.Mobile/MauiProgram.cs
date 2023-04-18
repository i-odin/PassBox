using PassBox.Mobile.DataBase;
using PassBox.Mobile.ViewModels;
using PassBox.Mobile.Views;

namespace PassBox.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
            .AddSqlite<ApplicationContext>($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PassBox.db")}")
            //.AddDbContextFactory<ApplicationContext>(options => options.UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PassBox.db")}"))
            .AddSingleton<PasswordInfoListViewModel>()
            .AddSingleton<PasswordInfoAddUpdateViewModel>()
            .AddSingleton<PasswordInfoListPage>()
            .AddSingleton<PasswordInfoAddUpdatePage>();


        return builder.Build();
    }
}