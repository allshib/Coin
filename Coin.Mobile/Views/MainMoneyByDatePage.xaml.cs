using Coin.Mobile.Services.Repositories;
using Coin.Mobile.ViewModels;
using Coin.Module.Models;
using Coin.Module.Services;
using DevExpress.Xpo.DB;

namespace Coin.Mobile.Views;

public partial class MainMoneyByDatePage : ContentPage
{
	public MainMoneyByDatePage(IDataStore<MoneyByDate> dataStore)
	{
		InitializeComponent();
        ViewModel = new MainMoneyByDateViewModel(dataStore);
        BindingContext = ViewModel;

        //ViewModel.DataStore.AddItemAsync(new MoneyByDate()
        //{
        //    Date = DateTime.UtcNow,
        //    Sum = 100
        //});

        //ViewModel.DataStore.AddItemAsync(new MoneyByDate()
        //{
        //    Date = DateTime.UtcNow,
        //    Sum = 150
        //});
        //ViewModel.DataStore.AddItemAsync(new MoneyByDate()
        //{
        //    Date = DateTime.UtcNow.AddDays(1),
        //    Sum = 100
        //});

        //ViewModel.DataStore.AddItemAsync(new MoneyByDate()
        //{
        //    Date = DateTime.UtcNow.AddDays(1).AddDays(4),
        //    Sum = 1006
        //});

        //ViewModel.DataStore.SaveChangesAsync();

        //ViewModel.UpdateSums();
    }

    MainMoneyByDateViewModel ViewModel { get; }
}