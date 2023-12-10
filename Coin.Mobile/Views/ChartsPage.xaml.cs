using Coin.Mobile.ViewModels;
using Coin.Module.Models;
using DevExpress.Maui.Charts;

namespace Coin.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartsPage : ContentPage
    {
        public ChartsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ChartsViewModel();
            ViewModel.OnAppearing();
        }

        ChartsViewModel ViewModel { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        private void chart_SelectionChanged(object sender, DevExpress.Maui.Charts.SelectionChangedEventArgs e)
        {
            var item = (Item)((DataSourceKey)e.SelectedObjects.FirstOrDefault()).DataObject;

            item.Value += 50;
            ViewModel.OnAppearing();
        }
    }
}