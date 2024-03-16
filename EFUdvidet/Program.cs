using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic;
using EFUdvidet.Models;
using UiModels;

class Program
{
    static async Task Main()
    {
        AuthorBL authorBL = new AuthorBL();
        BookBL bookBL = new BookBL();
        StoreBL storeBL = new StoreBL();

        while (true)
        {
            Console.WriteLine("Welcome to the Store, Author, and Book Management System.");
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Manage Stores");
            Console.WriteLine("2. Manage Authors");
            Console.WriteLine("3. Manage Books");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ManageStores(storeBL);
                    break;
                case "2":
                    await ManageAuthors(authorBL);
                    break;
                case "3":
                    await ManageBooks(bookBL);
                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static async Task ManageStores(StoreBL storeBL)
    {
        while (true)
        {
            Console.WriteLine("Store Management Menu:");
            Console.WriteLine("0. Show All Stores");
            Console.WriteLine("1. Create Store");
            Console.WriteLine("2. Update Store");
            Console.WriteLine("3. Delete Store");
            Console.WriteLine("4. Return to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    await ShowAllStores(storeBL);
                    break;
                case "1":
                    await CreateStore(storeBL);
                    break;
                case "2":
                    await UpdateStore(storeBL);
                    break;
                case "3":
                    await DeleteStore(storeBL);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ShowAllStores(StoreBL storeBL)
    {
        List<StoreUi> storeList = await storeBL.GetStoresAsync();

        if (storeList.Count == 0)
        {
            Console.WriteLine("No stores found.");
            return;
        }

        Console.WriteLine("All stores:");
        foreach (var storeUi in storeList)
        {
            Console.WriteLine($"ID: {storeUi.Id}, Name: {storeUi.Name}");
        }
    }

    static async Task CreateStore(StoreBL storeBL)
    {
        Console.WriteLine("Enter store name:");
        string name = Console.ReadLine();
        StoreUi storeUi = new StoreUi { Name = name };
        await storeBL.CreateStoreAsync(storeUi);
        Console.WriteLine("Store created successfully.");
    }

    static async Task UpdateStore(StoreBL storeBL)
    {
        Console.WriteLine("Enter store ID to update:");
        int storeId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new store name:");
        string name = Console.ReadLine();

        StoreUi storeUi = new StoreUi { Id = storeId, Name = name };
        await storeBL.UpdateStoreAsync(storeUi);

        Console.WriteLine("Store updated successfully.");
    }

    public static async Task DeleteStore(StoreBL storeBL)
    {
        Console.WriteLine("Enter store ID to delete:");
        int storeId = int.Parse(Console.ReadLine());
        StoreUi storeUiToDelete = new StoreUi { Id = storeId };
        await storeBL.DeleteStoreAsync(storeUiToDelete);
        Console.WriteLine("Store deleted successfully.");
    }

    static async Task ManageAuthors(AuthorBL authorBL)
    {
        while (true)
        {
            Console.WriteLine("Author Management Menu:");
            Console.WriteLine("0. Show All Authors");
            Console.WriteLine("1. Create Author");
            Console.WriteLine("2. Update Author");
            Console.WriteLine("3. Delete Author");
            Console.WriteLine("4. Return to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    await ShowAllAuthors(authorBL);
                    break;
                case "1":
                    await CreateAuthor(authorBL);
                    break;
                case "2":
                    await UpdateAuthor(authorBL);
                    break;
                case "3":
                    await DeleteAuthor(authorBL);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ShowAllAuthors(AuthorBL authorBL)
    {
        List<AuthorUI> authorUis = await authorBL.GetAuthorAsync();
        if (authorUis.Count == 0)
        {
            Console.WriteLine("No Authors found");
            return;
        }
        Console.WriteLine("All Authors:");
        foreach (AuthorUI authorUI in authorUis)
        {
            Console.WriteLine($"ID: {authorUI.Id}, Name: {authorUI.FirstName} {authorUI.LastName}");
        }
    }
    static async Task CreateAuthor(AuthorBL authorBL)
    {
        Console.WriteLine("Enter Author firstname:");
        string fName = Console.ReadLine();
        Console.WriteLine("Enter Author lastname:");
        string lName = Console.ReadLine();
        AuthorUI authorUI = new AuthorUI { FirstName = fName, LastName = lName };
        await authorBL.CreateAuthorAsync(authorUI);
        Console.WriteLine("Author created successfully");
    }
    static async Task UpdateAuthor(AuthorBL authorBL)
    {
        Console.WriteLine("Enter Author ID to update: ");
        int authorID=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter new Author Firstname:");
        string firstName= Console.ReadLine();
        Console.WriteLine("Enter new Author Lastname: ");
        string lastName= Console.ReadLine();
        AuthorUI authorUI=new AuthorUI { FirstName=firstName,LastName=lastName };
        await authorBL.UpdateAuthorAsync(authorUI);
        Console.WriteLine("Author updated succesfully");
    }
    static async Task DeleteAuthor(AuthorBL authorBL)
    {
        Console.WriteLine("Enter Author ID to delete:");
        int authorID=int.Parse(Console.ReadLine());
        AuthorUI authorUI = new AuthorUI { Id = authorID };
        await authorBL.DeleteAuthorAsync(authorUI);
        Console.WriteLine("Author deleted succesfully");
    }

    static async Task ManageBooks(BookBL bookBL)
    {
        while (true)
        {
            Console.WriteLine("Author Management Menu:");
            Console.WriteLine("0. Show All Authors");
            Console.WriteLine("1. Create Author");
            Console.WriteLine("2. Update Author");
            Console.WriteLine("3. Delete Author");
            Console.WriteLine("4. Return to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    await ShowAllBooks(bookBL);
                    break;
                case "1":
                    await CreateBook(bookBL);
                    break;
                case "2":
                    await UpdateBook(bookBL);
                    break;
                case "3":
                    await DeleteBook(bookBL);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ShowAllBooks(BookBL bookBL)
    {
        List<BookUi> bookUiList = await bookBL.GetBooksAsync();
        if (bookUiList.Count == 0)
        {
            Console.WriteLine("No books found");
            return; 
        }
        Console.WriteLine("All Books:");
        foreach(BookUi bookUi in bookUiList)
        {
            Console.WriteLine($"ID: {bookUi.Id}, Title: {bookUi.Title}, Publishdate: {bookUi.PublishDate}, Store ID: {bookUi.StoreID}, Author ID: {bookUi.AuthorId}");
        }
    }
    static async Task CreateBook(BookBL bookBL)
    {
        Console.WriteLine("Enter Book Title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Book Publishdate (yyyy-MM-dd):");
        string publishdateInput = Console.ReadLine();
        DateTime publishdate;
        if (!DateTime.TryParse(publishdateInput, out publishdate))
        {
            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
            return;
        }
        Console.WriteLine("Enter Book Store ID:");
        if (!int.TryParse(Console.ReadLine(), out int storeID))
        {
            Console.WriteLine("Invalid store ID. Please enter a valid integer.");
            return;
        }
        Console.WriteLine("Enter Book Author ID:");
        if (!int.TryParse(Console.ReadLine(), out int authorID))
        {
            Console.WriteLine("Invalid author ID. Please enter a valid integer.");
            return;
        }
        BookUi bookUi = new BookUi
        {
            Title = title,
            PublishDate = publishdate,
            StoreID = storeID,
            AuthorId = authorID
        };
        await bookBL.CreateBookAsync(bookUi);
    }

    static async Task UpdateBook(BookBL bookBL)
    {
        Console.WriteLine("Enter Book Title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Book Publishdate (yyyy-MM-dd):");
        string publishdateInput = Console.ReadLine();
        DateTime publishdate;
        if (!DateTime.TryParse(publishdateInput, out publishdate))
        {
            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
            return;
        }

        Console.WriteLine("Enter Book Store ID:");
        if (!int.TryParse(Console.ReadLine(), out int storeID))
        {
            Console.WriteLine("Invalid store ID. Please enter a valid integer.");
            return;
        }

        Console.WriteLine("Enter Book Author ID:");
        if (!int.TryParse(Console.ReadLine(), out int authorID))
        {
            Console.WriteLine("Invalid author ID. Please enter a valid integer.");
            return;
        }

        BookUi bookUi = new BookUi
        {
            Title = title,
            PublishDate = publishdate,
            StoreID = storeID,
            AuthorId = authorID
        };

        await bookBL.UpdateBookAsync(bookUi);
    }

    static async Task DeleteBook(BookBL bookBL)
    {
        Console.WriteLine("Enter Book ID to delete:");
        int bookID=int.Parse(Console.ReadLine());
        BookUi bookUi = new BookUi { Id = bookID };
        await bookBL.DeleteBookAsync(bookUi);
        Console.WriteLine("Book deleted succesfully");
    }
}
