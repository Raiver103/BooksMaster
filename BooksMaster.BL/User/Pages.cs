using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.User
{
    [Serializable]
    public class Pages
    {
        public int Id { get; set; }
        public int FirstPage { get; set; }
        public int AllPages { get; set; }
        public DateTime DateTime { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Pages()
        {

        }
        public Pages(int start, int all, Book book, User user, DateTime dateTime)
        {
            FirstPage = start;
            AllPages = all;
            Book = book;
            User = user;
            DateTime = dateTime;
        } 
    }
}
