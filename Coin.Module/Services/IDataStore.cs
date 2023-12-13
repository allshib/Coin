namespace Coin.Module.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(string id);

        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<IEnumerable<T>> GetItemsForFilter(Func<T,bool> filter);

        Task<bool> SaveChangesAsync();
       
    }

}
