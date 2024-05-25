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
        /// <summary>
        /// Метод возвращает список всех пользователей из базы данных
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            using (var db = new AppContext())
            {
                return db.Users.ToList();
            }
        }
        /// <summary>
        /// Метод возвращает конкретного пользователя по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }
        /// <summary>
        /// Метод добавляет пользователя в базу данных
        /// </summary>
        /// <param name="name"></param>
        public static void AddUserToDb(string name)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(new User { Name = name });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод удаляет пользователя из базы данных по его Id
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteUserFromDb(int id) 
        {
            using (var db = new AppContext())
            {
                var userToDelete = db.Users.FirstOrDefault(u => u.Id == id);    
                db.Users.Remove(userToDelete);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод обновляет имя пользователя в базе данных получае к нему доступ по Id пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newUserName"></param>
        public static void UpdateUserNameById(int id, string newUserName)
        {
            using (var db = new AppContext())
            {
                var userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);
                userToUpdate.Name = newUserName;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод возвращает булевый флаг извещающий о наличии у конкретного пользователя книги с конкретным названием 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool GetBookInUserByTitle(string title)
        {
            bool isUserHaveBook;
            using (var db = new AppContext())
            {
                return isUserHaveBook = db.Books.Include(b => b.User).Where(b => b.title == title).Any();
            }
        }
        /// <summary>
        /// Метод возвращает количество книг на руках у пользователя
        /// </summary>
        /// <returns></returns>
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
