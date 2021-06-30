using BooksMaster.BL.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.User
{
    public class UserController : BaseSerrializations
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool NewUserFlag { get; } = false;

        public void SAVE() 
        {
            Save(Users);
        }

        public List<User> LOAD() 
        {
            return Load<User>();
        }

        public UserController(string name)
        {
            
            Users = LOAD();
            CurrentUser = Users.SingleOrDefault(u => u.Name == name);

            if (CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                NewUserFlag = true;
            }

        }
        
        public void NewBook(List< Book> book)
        {
            CurrentUser.MyBooks = book;
            SAVE();
        }

        public void NewUser(string age)
        {
            CurrentUser.Age = age;
            SAVE();
        }

        public UserController() { }
    }
}

