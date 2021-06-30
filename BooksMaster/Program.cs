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
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var bookController = new BookController(userController.CurrentUser);
            if (userController.NewUserFlag)
            {
                Console.WriteLine("Please press you age!");
                var age = Console.ReadLine();
                userController.NewUser(age);
              
            }

            Console.WriteLine($"Привет! {userController.CurrentUser.Name}\n");


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
                        var first = ParseDouble("\npress first page");
                        var all = ParseDouble("\npress all page");
                        var date = ParseDate("\npress date read");
                        bookController.Add(nameBook, first, all, date);
                        Console.WriteLine("\nТвои книги: ");
                        CWInfo();
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("\npress name book");
                        var delete = Console.ReadLine();
                        bookController.DeleteBook(delete);
                        Console.WriteLine("\nbook eleted!");
                        CWInfo();
                        break;
                    case ConsoleKey.T:
                        Console.WriteLine("press page book");
                        var nameBookk = EnterBook();
                        var page = ParseDouble("\npage");
                        var dateRead = ParseDate("\ndate time");
                        bookController.ChangeFirstPage(nameBookk.Name, page, dateRead);
                        Console.WriteLine($"nice! you read {bookController.Read} pages! ");
                        Console.WriteLine("book editor!");
                        CWInfo();
                        break;
                    case ConsoleKey.Y:
                        Console.WriteLine("press new all page book");
                        var nameBookkk = EnterBook();
                        var allpage = ParseDouble("\nAll page:");
                        bookController.ChangeAllPages(nameBookkk.Name, allpage);
                        Console.WriteLine("book editor!");
                        CWInfo();
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine("**********************************************************");
                        foreach (var item in bookController.Sohr)
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

            int ParseDouble(string nname)
            {
                while (true)
                {
                    Console.WriteLine(nname);
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
            
            DateTime ParseDate(string nname)
            {
                while (true)
                {
                    Console.WriteLine(nname);
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
