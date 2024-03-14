using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUdvidet.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class StoreDbAccess
    {
        DatabaseContext db;

        public StoreDbAccess()
        {
            db= new DatabaseContext();
        }

        //Store
        public async Task<List<Store>> GetAsync()
        {
            return await db.Stores.ToListAsync();
        }

        public async Task<Store> GetAsync(int storeID)
        {
            Store store = await db.Stores.FindAsync(storeID);
            return store;
        }

        public async Task OpretButikAsync(string storeName)
        {
            Store nyButik = new Store
            {
                Name = storeName
            };
            db.Stores.Add(nyButik);

            await db.SaveChangesAsync();
        }
    }
}
