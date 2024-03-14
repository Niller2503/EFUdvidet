using DataAccess;
using EFUdvidet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AuthorBL
    {
        AuthorDataAccess db= new AuthorDataAccess();

        public async Task<List<Author>> GetAuthorAsync()
        {
            return await db.GetAuthorAsync();
        }
        public async Task<Author>GetAuthorAsync(int authorID)
        {
            return await db.GetAuthorAsync(authorID);
        }
        public async Task CreateAuthorAsync(string fornavn, string efternavn)
        {
            await db.CreateAuthorAsync(fornavn, efternavn);
        }
        public async Task UpdateAuthorAsync(int authorID, string nyFornavn, string nyEfternavn)
        {
            await db.UpdateAuthorAsync(authorID, nyFornavn, nyEfternavn);
        }
        public async Task DeleteAuthorAsync(int authorID)
        {
            await db.DeleteAuthorAsync(authorID);
        }
    }
}
