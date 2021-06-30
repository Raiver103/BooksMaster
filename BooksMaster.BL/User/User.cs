using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.User
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public List<Book> MyBooks { get; set; }
       

        public User(string name)
        {
            Name = name;
        }
        public User(List<Book> myBooks)
        {
            MyBooks = myBooks;
        }

        public User(string name, string age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name}, {Age}. ";
        }

        public User() { }
    }
}
