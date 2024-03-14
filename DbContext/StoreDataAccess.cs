using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUdvidet.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class StoreDataAccess
    {
        DatabaseContext db;

        public StoreDataAccess()
        {
            db= new DatabaseContext();
        }

        //Store
        public async Task<List<Store>> GetStoreAsync()
        {
            return await db.Stores.ToListAsync();
        }

        public async Task<Store> GetStoreAsync(int storeID)
        {
            return await db.Stores.FindAsync(storeID);
        }

        public async Task CreateStoreAsync(string storeName)
        {
            Store nyButik = new Store
            {
                Name = storeName
            };
            db.Stores.Add(nyButik);

            await db.SaveChangesAsync();
        }
        public async Task UpdateStoreAsync(int storeID, string newStoreName)
        {
            Store store =await db.Stores.FindAsync(storeID);
            if (store != null)
            {
                store.Name = newStoreName;
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteStoreAsync(int storeID)
        {
            Store store= await db.Stores.FindAsync(storeID);
        if (store != null)
            {
                db.Stores.Remove(store);
            }
        }
    }
}
