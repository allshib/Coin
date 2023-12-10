using Coin.Mobile.ViewModels;
using System.Runtime.CompilerServices;

namespace Coin.Mobile.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}