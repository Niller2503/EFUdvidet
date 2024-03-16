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
        ConvertDbToUi cb= new ConvertDbToUi();


        public async Task<List<AuthorUI>> GetAuthorAsync()
        {
            List<AuthorUI> authorUIList = new List<AuthorUI>();
            foreach(Author author in await db.GetAuthorAsync())
            {
                AuthorUI convertedAuthor = cb.ConvertToAuthorUi(author);
                authorUIList.Add(convertedAuthor);
            }
            return authorUIList;
        }
        public async Task<AuthorUI>GetAuthorAsync(int authorID)
        {
            List<BookUi> bookList = new List<BookUi>();
            Author author = await db.GetAuthorAsync(authorID);
            foreach(Book book in author.books)
            {
                BookUi convertedBooks= cb.ConvertToBookUi(book);
                bookList.Add(convertedBooks);
            }
            AuthorUI authorUI = cb.ConvertToAuthorUi(author);
            authorUI.Books = bookList;
            return cb.ConvertToAuthorUi(author);
        }
        public async Task<bool> CreateAuthorAsync(AuthorUI authorUi)
        {
             Author author = await cn.ConvertToAuthor(authorUi);
            return await db.CreateAuthorAsync(author);
        }
        public async Task<bool> UpdateAuthorAsync(AuthorUI authorUi)
        {
            Author author = await cn.ConvertToAuthor(authorUi);
                return await db.UpdateAuthorAsync(author);
        }
        public async Task DeleteAuthorAsync(AuthorUI authorUi)
        {
            Author author = await cn.ConvertToAuthor(authorUi);
            await db.DeleteAuthorAsync(author);
        }

        //private Author Convert(AuthorUI authorUI)
        //{
        //    cn.ConvertToAuthor(authorUI);
        //    return authorUI;
        //}
    }
}
