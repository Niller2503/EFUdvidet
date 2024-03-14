using EFUdvidet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorDataAccess
    {
        DatabaseContext db;

        public AuthorDataAccess()
        {
            db = new DatabaseContext();
        }
        public async Task<List<Author>> GetAuthorAsync()
        {
            return await db.Authors.ToListAsync();
        }
        public async Task<Author> GetAuthorAsync(int authorID)
        {
            return await db.Authors.FindAsync(authorID);
        }
        public async Task CreateAuthorAsync(string fornavn, string efternavn)
        {
            Author newAuthor = new Author
            {
                FirstName = fornavn,
                LastName = efternavn
            };
            db.Authors.Add(newAuthor);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAuthorAsync(int authorID, string nyFornavn, string nyEfternavn)
        {
            Author author = await db.Authors.FindAsync(authorID);
            if (author != null)
            {
                author.FirstName = nyFornavn;
                author.LastName = nyEfternavn;
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteAuthorAsync(int authorID)
        {
            Author author = await db.Authors.FindAsync(authorID);
            if (author != null)
            {
                db.Authors.Remove(author);
            }
        }
    }
}
