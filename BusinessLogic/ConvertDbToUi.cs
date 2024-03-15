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
            AuthorUI authorUI = new AuthorUI();
            authorUI.Id = author.Id;
            authorUI.FirstName = author.FirstName;
            authorUI.LastName = author.LastName;
            authorUI.Books = author.books.Select(book => book.Id).ToList(); 

            return authorUI;
        }
        public BookUi ConvertToBookUi(Book book) 
        {
            BookUi bookUI = new BookUi();
            bookUI.Id = book.Id;
            bookUI.Title = book.Title;
            bookUI.PublishDate = book.PublishDate;
            bookUI.StoreID = book.StoreID;
            bookUI.AuthorId = book.AuthorId;

            return bookUI;
        }
        public StoreUi ConvertToStoreUi(Store store)
        {
            StoreUi storeUI = new StoreUi();
            storeUI.Id = store.Id;
            storeUI.Name = store.Name;

            return storeUI;
        }
    }
}
