using BooksMaster.BL.Controllers;
using BooksMaster.BL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваще имя чтобы войти!");
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var bookController = new BookController(userController.CurrentUser);
            if (userController.NewUserFlag)
            {
                Console.WriteLine("Please press you age!");
                var userAge = Console.ReadLine();
                userController.NewUser(userAge);
              
            }

            Console.WriteLine($"Hello! {userController.CurrentUser.Name}\n");


            if (!userController.NewUserFlag)
            {
                CWInfo();
            }

            while (true)
            {
                

                Console.WriteLine("**********************************");
                Console.WriteLine($"\nPress E to add book");
                Console.WriteLine($"Press R to delete book");
                Console.WriteLine($"Press T to edit pagers in book");
                Console.WriteLine($"Press Y to edit all pagers in book");
                Console.WriteLine($"Press U to warh all info");
                Console.WriteLine("\n**********************************");
                
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var nameBook = EnterBook();
                        var firstPage = ParseDouble("\npress first page");
                        var allPage = ParseDouble("\npress all page");
                        var dateRead = ParseDate("\npress date read");
                        bookController.Add(nameBook, firstPage, allPage, dateRead);
                        Console.WriteLine("\nТвои книги: ");
                        CWInfo();
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("\npress name book");
                        var deleteNameBook = Console.ReadLine();
                        bookController.DeleteBook(deleteNameBook);
                        Console.WriteLine("\nbook eleted!");
                        CWInfo();
                        break;
                    case ConsoleKey.T:
                        Console.WriteLine("press page book");
                        var nameBookEdit = EnterBook();
                        var pageEdit = ParseDouble("\npage");
                        var dateReadEdit = ParseDate("\ndate time");
                        bookController.ChangeFirstPage(nameBookEdit.Name, pageEdit, dateReadEdit);
                        Console.WriteLine($"nice! you read {bookController.Read} pages! ");
                        Console.WriteLine("book editor!");
                        CWInfo();
                        break;
                    case ConsoleKey.Y:
                        Console.WriteLine("press new all page book");
                        var nameBookAll = EnterBook();
                        var allPageEdit = ParseDouble("\nAll page:");
                        bookController.ChangeAllPages(nameBookAll.Name, allPageEdit);
                        Console.WriteLine("book editor!");
                        CWInfo();
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine("**********************************************************");
                        foreach (var item in bookController.Archive)
                        {
                            Console.WriteLine($" book: {item.Book}, first: {item.FirstPage}, all: {item.AllPages}, data: {item.DateTime}, ({bookController.Read}).");
                        }
                        Console.WriteLine("**********************************************************");
                        CWInfo();
                        break;
                }
            }

            Book EnterBook()
            {
                Console.WriteLine($"\npls press name book");
                var nameBook = Console.ReadLine();
                return new Book(nameBook);
            }

            int ParseDouble(string nameBook)
            {
                while (true)
                {
                    Console.WriteLine(nameBook);
                    if (int.TryParse(Console.ReadLine(), out int valye))
                    {
                        return valye;
                    }
                    else
                    {
                        Console.WriteLine("\nНекоректное число(2).");
                    }
                }
            }
            
            DateTime ParseDate(string date)
            {
                while (true)
                {
                    Console.WriteLine(date);
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime valye))
                    {
                        return valye;
                    }
                    else
                    {
                        Console.WriteLine("\nНекоректное число(2).");
                    }
                }
            }

            void CWInfo()
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("Твоя последняя прочитанная страница: ");
                foreach (var i in bookController.Pages)
                {
                    Console.WriteLine($"Name book: {i.Book}, all: {i.AllPages}, first: {i.FirstPage}.");
                }
                Console.WriteLine("***************************************");
            }

        }
    }
}
