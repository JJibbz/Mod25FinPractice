using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod25FinPractice.Repo
{
    public class BookRepository
    {
        /// <summary>
        /// Метод возвращает список всех книг, имеющихся в библиотеке
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {
                return db.Books.ToList();
            }
        }
        /// <summary>
        /// Метод возвращает конкретную книгу по её Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Book GetBookById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.FirstOrDefault(b => b.Id == id);
            }
        }
        /// <summary>
        /// Метод добавляет книгу в базу данных
        /// </summary>
        /// <param name="tit"></param>
        /// <param name="pubDate"></param>
        /// <param name="aut"></param>
        /// <param name="gen"></param>
        public static void AddBookToDb(string tit, int pubDate, string aut, string gen)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(new Book { title = tit, publicationDate = pubDate, author = aut, genre = gen });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод удаляет книгу их базы данных по её Id
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteBookFromDb(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод обновляет дату публикации в книге, получая к ней доступ по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPubDate"></param>
        public static void UpdatePubDateById(int id, int newPubDate)
        {
            using (var db = new AppContext())
            {
                var bookToUpdate = db.Books.FirstOrDefault(b => b.Id == id);
                bookToUpdate.publicationDate = newPubDate;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод возвращает список книг по жанру и диапазону дат публикации
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public static List<Book> GetBookListByGenreAndDate(string genre, int firstDate, int secondDate)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(b => b.genre == genre && b.publicationDate > firstDate && b.publicationDate < secondDate).ToList();
            }
        }
        /// <summary>
        /// Метод возвращает количество книг, имеющихся в библиотеке от конкретного автора
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static int GetBookByAuthorCount(string author)
        {
            int count;
            using (var db = new AppContext())
            {
                return count = db.Books.Where(b => b.author == author).Count();
            }
        }
        /// <summary>
        /// Метод возвращает количество книг конкретного жанра, имеющихся в библиотеке 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static int GetBookByGenreCount(string genre)
        {
            int count;
            using (var db = new AppContext())
            {
                return count = db.Books.Where(b => b.genre == genre).Count();
            }
        }
        /// <summary>
        /// Метод возвращает булевый флаг наличия книги в библиотеке по её автору и названию
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool GetBookAvailabilityByAuthorAndTitle(string author, string title)
        {
            bool isBookAvailable;
            using (var db = new AppContext())
            {
                return isBookAvailable = db.Books.Where(b => b.author == author && b.title == title).Any();
            }
        }
        /// <summary>
        /// Метод возвращает последнюю изданную книгу
        /// </summary>
        /// <returns></returns>
        public static Book GetLastPublishedBook()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.publicationDate).First();
            }
        }
        /// <summary>
        /// Метод возвращает список всех книг, имеющихся в библиотеке, отсортированный в алфавитном порядке
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetAlphabetListOfBooksByTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(b => b.title).ToList();
            }
        }
        /// <summary>
        /// Метод возвращает список всех книг имеющихся в библиотеке, отсортированный по убыванию по дате их публикации
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetDescendingListOfBooksByPubDate()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.publicationDate).ToList();
            }
        }
    }
}
