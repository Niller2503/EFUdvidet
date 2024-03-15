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
        public Author ConvertToAuthor(AuthorUI authorUi)
        {
            Author author = new Author();
            author.Id=authorUi.Id;
            author.FirstName=authorUi.FirstName;
            author.LastName=authorUi.LastName;

            return author;
        }
        public Book ConvertToBook(BookUi bookUi)
        {
            Book book = new Book();
            book.Id=bookUi.Id;
            book.Title=bookUi.Title;
            book.PublishDate=bookUi.PublishDate;
            book.StoreID = bookUi.StoreID;
            book.AuthorId=bookUi.AuthorId;

            return book;
        }
        public Store ConvertToStore(StoreUi storeUi)
        {
            Store store = new Store();
            store.Id=storeUi.Id;
            store.Name=storeUi.Name;

            return store;
        }
    }
}
