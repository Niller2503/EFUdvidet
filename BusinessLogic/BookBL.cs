using DataAccess;
using EFUdvidet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BookBL
    {
        BookDataAccess db = new BookDataAccess();

        public async Task<List<Book>> GetBooksAsync()
        {
            return await db.GetBooksAsync();
        }
        public async Task<Book> GetBooksAsync(int bookID)
        {
            return await db.GetBooksAsync(bookID);
        }
        public async Task CreateBookAsync(string title, DateTime publishDate, int storeID, int authorID)
        {
            await db.CreateBookAsync(title, publishDate, storeID, authorID);
        }
        public async Task UpdateBookAsync(int bookID, string title, DateTime publishDate, int storeID, int authorID)
        {
            await db.UpdateBookAsync(bookID, title, publishDate, storeID, authorID);
        }
        public async Task DeleteBookAsync(int bookID)
        {
            await db.DeleteBookAsync(bookID);
        }
    }
}
