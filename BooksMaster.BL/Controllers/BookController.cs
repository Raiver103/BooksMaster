using BooksMaster.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.User
{
    public class BookController : BaseSerrializations
    {
        public readonly User user;
        public List<Pages> Pages { get; }
        public List<Book> Books { get; }
        public List<NewPage> Sohr { get; }
        public int Read { get; set; }

        public BookController(User user)
        {
            this.user = user;
            Pages = LoadPages();
            Books = LoadBooks();
            Sohr = LoadNewPage();
        }
        
        public BookController() { }

        public void Add(Book book, int startPage, int endPage, DateTime dateTime)
        {
            var act = Books.SingleOrDefault(f => f.Name == book.Name);

            if (act == null)
            {
                Books.Add(book);
                var exersize = new Pages(startPage, endPage , book, user, dateTime);
                Pages.Add(exersize);
                var newPages = new NewPage(exersize.FirstPage, exersize.AllPages, exersize.Book, exersize.User, exersize.DateTime);
                Sohr.Add(newPages);

                SAVE();
            }
            else
            {
                Console.WriteLine("\nThis name here yes");
            }
            SAVE();
        }

        public void DeleteBook(string name) 
        {
            var DeleteBook =  Books.SingleOrDefault(i => i.Name == name);
            var DeletePages =  Pages.SingleOrDefault(i => i.Book.Name == name);

            if(DeleteBook != null)
            {
                Books.Remove(DeleteBook);
                Pages.Remove(DeletePages);
                SAVE();
            }
            else
                Console.WriteLine("\nhere is no book with that name");
        }
        
        public void ChangeFirstPage(string name, int page, DateTime dateTime) 
        {
            var ChangeFirstBook = Pages.SingleOrDefault(i => i.Book.Name == name);

            if(ChangeFirstBook != null)
            {
                Pages.Remove(ChangeFirstBook);

                var newFirstPage = new Pages(page, ChangeFirstBook.AllPages , ChangeFirstBook.Book, ChangeFirstBook.User, dateTime);
                Pages.Add(newFirstPage);
                
                var newPages = new NewPage(newFirstPage.FirstPage, newFirstPage.AllPages, newFirstPage.Book, newFirstPage.User, newFirstPage.DateTime);
                Sohr.Add(newPages);

                Read = (newFirstPage.FirstPage - ChangeFirstBook.AllPages) - (ChangeFirstBook.FirstPage - ChangeFirstBook.AllPages);

                Console.WriteLine($"\nnice! you read {Read} pages! ");
                SAVE();
            }
            else
                Console.WriteLine("\nThere is no book with that name");
        }
        
        public void ChangeAllPages(string name, int page) 
        {
            var ChangeAllBook = Pages.SingleOrDefault(i => i.Book.Name == name);
            if (ChangeAllBook != null)
            {
                Pages.Remove(ChangeAllBook);

                var newAllPage = new Pages(ChangeAllBook.FirstPage, page, ChangeAllBook.Book, ChangeAllBook.User, ChangeAllBook.DateTime);
                Pages.Add(newAllPage);
                SAVE();
            }
            else
                Console.WriteLine("\nThere is no book with that name");
        }

        public List<Book> LoadBooks()
        {
            return Load<Book>() ?? new List<Book>();
        }

        public List<Pages> LoadPages()
        {
            return Load<Pages>() ?? new List<Pages>();
        } 
        
        public List<NewPage> LoadNewPage()
        {
            return Load<NewPage>() ?? new List<NewPage>();
        }

        public void SAVE()
        {
            Save(Books);
            Save(Pages);
            Save(Sohr);
        }
    }
}
