using EFUdvidet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDataAccess
    {
        DatabaseContext db;

        public BookDataAccess()
        {
            db = new DatabaseContext();
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            return await db.Books.ToListAsync();
        }
        public async Task<Book> GetBooksAsync(int bookID)
        {
            return await db.Books.FindAsync(bookID);
        }
        public async Task CreateBookAsync(string title, DateTime publishDate, int storeID, int authorID)
        {
            Book newBook = new Book
            {
                Title = title,
                PublishDate = publishDate,
                StoreID = storeID,
                AuthorId = authorID
            };
            db.Books.Add(newBook);
            await db.SaveChangesAsync();
        }
        public async Task UpdateBookAsync(int bookID, string title, DateTime publishDate, int storeID, int authorID)
        {
            Book book = await db.Books.FindAsync(bookID);
            if (book != null)
            {
                book.Title = title;
                book.PublishDate = publishDate;
                book.StoreID = storeID;
                book.AuthorId = authorID;
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int bookID)
        {
            Book book = await db.Books.FindAsync(bookID);
            if (book != null)
            {
                db.Books.Remove(book);
            }
        }


    }
}
