using DataAccess;
using EFUdvidet.Models;

// Opretter nogle forfattere
List<Author> authors = new List<Author>
{
    new Author { FirstName = "John", LastName = "Smith", BookID = 1, books = new List<Book>() },
    new Author { FirstName = "Emily", LastName = "Brown", BookID = 2, books = new List<Book>() }
};

// Opretter nogle butikker
List<Store> stores = new List<Store>
{
    new Store { Name = "Book Haven", Books = new List<Book>() },
    new Store { Name = "Paperbacks & Co.", Books = new List<Book>() }
};

// Opretter nogle bøger og tilknytter dem til forfattere og butikker
List<Book> books = new List<Book>
{
    new Book { Title = "The Mystery of the Missing Key", PublishDate = DateTime.Parse("2023-01-15"), StoreID = 1, Store = stores[0], Author = authors[0] },
    new Book { Title = "A Tale of Two Cities", PublishDate = DateTime.Parse("2022-05-10"), StoreID = 2, Store = stores[1], Author = authors[1] }
};

authors[0].books.Add(books[0]);
authors[1].books.Add(books[1]);

stores[0].Books.Add(books[0]);
stores[1].Books.Add(books[1]);

//using DatabaseContext dbContext = new DatabaseContext();

//await dbContext.Authors.AddRangeAsync(authors);
//await dbContext.Books.AddRangeAsync(books);
//await dbContext.Stores.AddRangeAsync(stores);
//await dbContext.SaveChangesAsync();
Console.ReadLine();
