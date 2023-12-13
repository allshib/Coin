using Coin.Mobile.Services.Repositories;
using Coin.Mobile.Utilities;
using Coin.Mobile.Views;
using Coin.Module.Models;
using Coin.Module.Services;
using DevExpress.Data.Browsing;
using DevExpress.Maui;
using DevExpress.Xpo.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace Coin.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
                });
            builder.Services.AddDbContext<DataAccess.DataContext>();
            builder.Services.AddTransient<AboutPage>();
            builder.Services.AddTransient<MainMoneyByDatePage>();
            builder.Services.AddTransient<NewMoneyByDatePage>();

            builder.Services.AddTransient<IDataStore<MoneyByDate>, MoneyByDateRepository>();



            var dbContext = new DataAccess.DataContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            DevExpress.Maui.Charts.Initializer.Init();
            DevExpress.Maui.CollectionView.Initializer.Init();
            DevExpress.Maui.Controls.Initializer.Init();
            DevExpress.Maui.Editors.Initializer.Init();
            DevExpress.Maui.DataGrid.Initializer.Init();
            DevExpress.Maui.Scheduler.Initializer.Init();
            return builder.Build();
        }
    }
}
