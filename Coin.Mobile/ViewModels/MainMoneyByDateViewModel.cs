using Coin.Module.Models;
using Coin.Module.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Mobile.ViewModels
{
    public class MainMoneyByDateViewModel : BaseViewModel2<MoneyByDate>
    {


        public MainMoneyByDateViewModel(IDataStore<MoneyByDate> dataStore) : base(dataStore)
        {
            Title = "Главная страница";
        }

        private decimal todaySum;
        public decimal TodaySum
        {
            get => todaySum;
            set { SetProperty(ref this.todaySum, value);}
        }

        private decimal weekSum;
        public decimal WeekSum
        {
            get => 0;
            set { SetProperty(ref this.weekSum, value);}
        }
        private decimal monthSum;
        public decimal MonthSum
        {
            get => monthSum;
            set { SetProperty(ref this.monthSum, value); }
        }

        public void UpdateSums()
        {
            TodaySum = DataStore.GetItemsAsync().Result
                .Where(x => x.Date.Date == DateTimeOffset.UtcNow.Date).Sum(x => x.Sum);

            MonthSum = DataStore.GetItemsAsync().Result.Where(x =>
                        x.Date.Year == DateTimeOffset.UtcNow.Year &&
                        x.Date.Month == DateTimeOffset.UtcNow.Month).Sum(x => x.Sum);
        }

    }
}
