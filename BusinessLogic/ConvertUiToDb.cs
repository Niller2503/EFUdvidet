using System;
using EFUdvidet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiModels;

namespace BusinessLogic
{
    public class ConvertUiToDb
    {
        public async Task<Author> ConvertToAuthor(AuthorUI authorUI)
        {
            Author convertedAuthor = new Author()
            {
                Id = authorUI.Id,
                FirstName = authorUI.FirstName,
                LastName = authorUI.LastName
            };


            return convertedAuthor;
        }
        public async Task<Book> ConvertToBook(BookUi bookUi)
        {
            Book book = new Book
            {
                Id = bookUi.Id,
                Title = bookUi.Title,
                PublishDate = bookUi.PublishDate,
                StoreID = bookUi.StoreID,
                AuthorId = bookUi.AuthorId
            };

            return book;
        }
        public Store ConvertToStore(StoreUi storeUi)
        {
            Store store = new Store
            {
                Id = storeUi.Id,
                Name = storeUi.Name
            };

            return store;
        }
    }
}
