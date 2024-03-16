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
    public class BookBL
    {
        BookDataAccess db = new BookDataAccess();
        ConvertUiToDb cn = new ConvertUiToDb();
        ConvertDbToUi cb = new ConvertDbToUi();

        public async Task<List<BookUi>> GetBooksAsync()
        {
            var bookList = await db.GetBooksAsync();
            var bookUiList = new List<BookUi>();

            foreach (var book in bookList)
            {
                var convertedBook = cb.ConvertToBookUi(book);
                bookUiList.Add(convertedBook);
            }
            return bookUiList;
        }
        public async Task<BookUi> GetBookAsync(int bookID)
        {
            var book = await db.GetBooksAsync(bookID);
            var bookUi = cb.ConvertToBookUi(book);
            return bookUi;
        }
        public async Task<bool> CreateBookAsync(BookUi bookUi)
        {
            Book book = await cn.ConvertToBook(bookUi);
            return await db.CreateBookAsync(book);
        }

        public async Task<bool> UpdateBookAsync(BookUi bookUi)
        {
            var book = await cn.ConvertToBook(bookUi);
            return await db.UpdateBookAsync(book);
        }

        public async Task<bool> DeleteBookAsync(BookUi bookUi)
        {
            var book = await cn.ConvertToBook(bookUi);
            return await db.DeleteBookAsync(book);
        }
    }
}
