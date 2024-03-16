using EFUdvidet.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using UiModels;
namespace BusinessLogic
{
    public class StoreBL
    {
        StoreDataAccess db = new StoreDataAccess();
        ConvertUiToDb cn = new ConvertUiToDb();
        ConvertDbToUi cb = new ConvertDbToUi();

        public async Task<List<StoreUi>> GetStoresAsync()
        {
            List<StoreUi> storeUiList = new List<StoreUi>();
            foreach (Store store in await db.GetStoreAsync())
            {
                StoreUi convertedStore = cb.ConvertToStoreUi(store);
                storeUiList.Add(convertedStore);
            }
            return storeUiList;
        }
        public async Task<StoreUi> GetStoreAsync(int storeID)
        {
            Store store = await db.GetStoreAsync(storeID);
            return cb.ConvertToStoreUi(store);
        }
        public async Task<bool> CreateStoreAsync(StoreUi storeUi)
        {
            Store store = cn.ConvertToStore(storeUi);
            return await db.CreateStoreAsync(store);
        }
        public async Task<bool> UpdateStoreAsync(StoreUi storeUi)
        {
            Store store = cn.ConvertToStore(storeUi);
            return await db.UpdateStoreAsync(store);
        }
        public async Task DeleteStoreAsync(StoreUi storeUi)
        {
            Store store = cn.ConvertToStore(storeUi);
            await db.DeleteStoreAsync(store);
        }

    }
}
