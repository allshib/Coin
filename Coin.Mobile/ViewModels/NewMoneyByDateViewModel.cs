using Coin.Mobile.Services.Repositories;
using Coin.Module.Models;
using Coin.Module.Services;
using DevExpress.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Mobile.ViewModels
{
    public class NewMoneyByDateViewModel : BaseViewModel2<MoneyByDate>
    {
        public const string ViewName = "NewMoneyByDatePage";

        public NewMoneyByDateViewModel(IDataStore<MoneyByDate> repository) : base(repository)
        {
            currentObject = new MoneyByDate() { Id = Guid.NewGuid() };
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private MoneyByDate currentObject;
        public MoneyByDate CurrentObject
        {
            get => currentObject;
            set => SetProperty(ref currentObject, value);
        }


        [DataFormDisplayOptions(IsVisible = false)]
        public Command SaveCommand { get; }

        [DataFormDisplayOptions(IsVisible = false)]
        public Command CancelCommand { get; }


        bool ValidateSave()
        {
            return true;
        }

        async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }

        async void OnSave()
        {
            await DataStore.AddItemAsync(currentObject);
            await DataStore.SaveChangesAsync();
            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }

    }
}
