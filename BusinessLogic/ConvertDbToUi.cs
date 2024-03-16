using EFUdvidet.Models;
using UiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ConvertDbToUi
    {
        public AuthorUI ConvertToAuthorUi(Author author)
        {
            AuthorUI authorUI = new AuthorUI
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return authorUI;
        }

        public BookUi ConvertToBookUi(Book book)
        {
            BookUi bookUI = new BookUi
            {
                Id = book.Id,
                Title = book.Title,
                PublishDate = book.PublishDate,
                StoreID = book.StoreID,
                AuthorId = book.AuthorId
            };

            return bookUI;
        }

        public StoreUi ConvertToStoreUi(Store store)
        {
            StoreUi storeUI = new StoreUi
            {
                Id = store.Id,
                Name = store.Name
            };

            return storeUI;
        }
    }
}
