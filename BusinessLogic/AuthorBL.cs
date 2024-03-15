using DataAccess;
using EFUdvidet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiModels;

namespace BusinessLogic
{
    public class AuthorBL
    {
        AuthorDataAccess db= new AuthorDataAccess();
        ConvertUiToDb cn= new ConvertUiToDb();


        public async Task<List<Author>> GetAuthorAsync()
        {
            return await db.GetAuthorAsync();
        }
        public async Task<Author>GetAuthorAsync(int authorID)
        {
            return await db.GetAuthorAsync(authorID);
        }
        public async Task CreateAuthorAsync(AuthorUI authorUi)
        {
            
            await db.CreateAuthorAsync(AuthorUI authorUi);
        }
        public async Task UpdateAuthorAsync(int authorID, string nyFornavn, string nyEfternavn)
        {
            await db.UpdateAuthorAsync(authorID, nyFornavn, nyEfternavn);
        }
        public async Task DeleteAuthorAsync(int authorID)
        {
            await db.DeleteAuthorAsync(authorID);
        }

        private Author Convert(AuthorUI authorUI)
        {
            cn.ConvertToAuthor(authorUI);
            return authorUI;
        }
    }
}
