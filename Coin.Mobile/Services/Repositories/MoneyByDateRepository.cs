using Coin.Mobile.DataAccess;
using Coin.Module.Models;
using Coin.Module.Services;
using Microsoft.EntityFrameworkCore;


namespace Coin.Mobile.Services.Repositories
{
    public class MoneyByDateRepository : IDataStore<MoneyByDate>
    {
        private readonly DataContext context;

        public MoneyByDateRepository(DataContext context) {
            this.context = context;
        }

        public async Task<bool> AddItemAsync(MoneyByDate item)
        {
            if (item == null) return false;

            try
            {
                if(await context.MoneyByDates.AnyAsync(x=>x.Id == item.Id))
                    return true;

                await context.MoneyByDates.AddAsync(item);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var moneyByDate = await context.MoneyByDates.FindAsync(id);

            if(moneyByDate != null)
            {
                context.MoneyByDates.Remove(moneyByDate);
                return true;
            }

            return false;
        }

        public async Task<MoneyByDate> GetItemAsync(string id)
        {
            var moneyByDate = await context.MoneyByDates.FindAsync(id);

            if (moneyByDate != null)
            {
                return moneyByDate;
            }

            return null;
        }

        public async Task<IEnumerable<MoneyByDate>> GetItemsAsync(bool forceRefresh = false)
        {
            return context.MoneyByDates;
        }

        public async Task<IEnumerable<MoneyByDate>> GetItemsForFilter(Func<MoneyByDate, bool> filter)
        {
            return await context.MoneyByDates.Where(x => filter(x)).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            bool res = false;


            try
            {
                res = await context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                var et = ex.InnerException;
            }

            return res;
        }

        public async Task<bool> UpdateItemAsync(MoneyByDate item)
        {
            try
            {
                var oldItem = await context.MoneyByDates.FindAsync(item.Id);

                if (oldItem != null)
                {
                    context.MoneyByDates.Remove(oldItem);
                }

                await context.MoneyByDates.AddAsync(item);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
