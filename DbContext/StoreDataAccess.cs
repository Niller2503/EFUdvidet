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
            return await db
                .Stores
                .Include(b => b.Books)
                .ThenInclude(a => a.Author)
                .ToListAsync();
        }

        public async Task<Store> GetStoreAsync(int storeID)
        {
            return await db.Stores.FindAsync(storeID);
        }

        public async Task<bool> CreateStoreAsync(Store store)
        {
            db.Stores.Add(store);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateStoreAsync(Store updatedStore)
        {
            var existingStore= await db.Stores.FindAsync(updatedStore.Id);
            if (existingStore != null)
            {
                existingStore.Name = updatedStore.Name;

                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteStoreAsync(Store store)
        {
            db.Stores.Remove(store);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
