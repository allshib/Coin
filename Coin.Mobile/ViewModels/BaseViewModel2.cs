using Coin.Mobile.Services;
using Coin.Module.Models;
using Coin.Module.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Mobile.ViewModels
{
    public class BaseViewModel2<T> : INotifyPropertyChanged
    {
        bool isBusy = false;
        string title = string.Empty;

        private readonly IDataStore<T> dataStore;
        public IDataStore<T> DataStore
         => dataStore ?? DependencyService.Get<IDataStore<T>>();

        public INavigationService Navigation => DependencyService.Get<INavigationService>();

        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }

        public string Title
        {
            get { return this.title; }
            set { SetProperty(ref this.title, value); }
        }


        public BaseViewModel2(IDataStore<T> dataStore) 
        {
            this.dataStore = dataStore;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
