using Coin.Mobile.ViewModels;
using Coin.Module.Models;
using Coin.Module.Services;
using Microsoft.EntityFrameworkCore;

namespace Coin.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private readonly IDataStore<MoneyByDate> repository;
        public AboutPage(IDataStore<MoneyByDate> rep)
        {
            repository = rep;
            InitializeComponent();

        }
    }
}