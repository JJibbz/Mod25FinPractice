using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod25FinPractice.Repo
{
    public class UserRepository
    {
        public static List<User> GetAllUsers()
        {
            using (var db = new AppContext())
            {
                return db.Users.ToList();
            }
        }

        public static User GetUserById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public static void AddUserToDb(string name)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(new User { Name = name });
                db.SaveChanges();
            }
        }

        public static void DeleteUserFromDb(int id) 
        {
            using (var db = new AppContext())
            {
                var userToDelete = db.Users.FirstOrDefault(u => u.Id == id);    
                db.Users.Remove(userToDelete);
                db.SaveChanges();
            }
        }

        public static void UpdateUserNameById(int id, string newUserName)
        {
            using (var db = new AppContext())
            {
                var userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);
                userToUpdate.Name = newUserName;
                db.SaveChanges();
            }
        }

        public static bool GetBookInUserByTitle(string title)
        {
            bool isUserHaveBook;
            using (var db = new AppContext())
            {
                return isUserHaveBook = db.Books.Include(b => b.User).Where(b => b.title == title).Any();
            }
        }

        public static int GetBooksCountInUser()
        {
            int count;
            using (var db = new AppContext())
            {
                return count = db.Books.Include(b => b.User).Count();
            }
        }
    }
}
