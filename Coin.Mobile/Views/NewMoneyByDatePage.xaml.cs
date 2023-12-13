using Coin.Mobile.Services.Repositories;
using Coin.Mobile.ViewModels;
using Coin.Module.Models;
using Coin.Module.Services;

namespace Coin.Mobile.Views;

public partial class NewMoneyByDatePage : ContentPage
{
	public NewMoneyByDatePage(IDataStore<MoneyByDate> dataStore)
	{
		InitializeComponent();
		BindingContext = new NewMoneyByDateViewModel(dataStore);
    }
}