using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PassBox.Infrastructure.Data;
using PassBox.Mobile.ViewModels;
using PassBox.Mobile.Views;
using PassBox.Services;
using PassBox.Services.Cryptography;

namespace PassBox.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<SiteViewPage>();
            builder.Services.AddTransient<SiteEditPage>();

            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<SiteViewModel>();
            builder.Services.AddTransient<SiteEditViewModel>();

            builder.Services.AddScoped<IAccountSiteService, AccountSiteService>(); 
            builder.Services.AddScoped<IEncryptionService, EncryptionService>();
            builder.Services.AddScoped<IAlgorithmFactory, AlgorithmFactory>();
            
            builder.Services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlite("Filename=passboxdb.db"));

            return builder.Build();
        }
    }
}
