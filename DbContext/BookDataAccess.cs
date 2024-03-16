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
            return await db
                .Books
                .Include(a => a.Author)
                .ToListAsync();
        }
        public async Task<Book> GetBooksAsync(int bookID)
        {
            return await db.Books.FindAsync(bookID);
        }
        public async Task<bool> CreateBookAsync(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateBookAsync(Book updatedBook)
        {
            var existingBook = await db.Books.FindAsync(updatedBook.Id);

            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.PublishDate = updatedBook.PublishDate;
                existingBook.StoreID = updatedBook.StoreID;
                existingBook.AuthorId = updatedBook.AuthorId;

                await db.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> DeleteBookAsync(Book book)
        {
            var existingBook = await db.Books.FindAsync(book.Id);

            if (existingBook != null)
            {
                db.Books.Remove(existingBook);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
