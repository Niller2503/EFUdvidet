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
        public async Task<bool> CreateAuthorAsync(Author author)
        {
            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAuthorAsync(Author updatedAuthor)
        {
            var existingAuthor = await db.Authors.FindAsync(updatedAuthor.Id);

            if (existingAuthor != null)
            {
                existingAuthor.FirstName = updatedAuthor.FirstName;
                existingAuthor.LastName = updatedAuthor.LastName;

                await db.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> DeleteAuthorAsync(Author author)
        {
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
            return true;
        }

    }
}
