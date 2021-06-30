using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.User
{
    [Serializable]
    public class Book
    {
        public int Id { get; set; }
        public List<Pages> Pages { get; set; }
        public string Name { get; set; }
      
        public Book()
        {

        }
        public Book(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
