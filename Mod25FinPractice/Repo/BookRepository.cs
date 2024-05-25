using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod25FinPractice.Repo
{
    public class BookRepository
    {
        public static List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {
                return db.Books.ToList();
            }
        }

        public static Book GetBookById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.FirstOrDefault(b => b.Id == id);
            }
        }

        public static void AddBookToDb(string tit, int pubDate, string aut, string gen)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(new Book { title = tit, publicationDate = pubDate, author = aut, genre = gen });
                db.SaveChanges();
            }
        }

        public static void DeleteBookFromDb(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public static void UpdatePubDateById(int id, int newPubDate)
        {
            using (var db = new AppContext())
            {
                var bookToUpdate = db.Books.FirstOrDefault(b => b.Id == id);
                bookToUpdate.publicationDate = newPubDate;
                db.SaveChanges();
            }
        }

        public static List<Book> GetBookListByGenreAndDate(string genre, int firstDate, int secondDate)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(b => b.genre == genre && b.publicationDate > firstDate && b.publicationDate < secondDate).ToList();
            }
        }

        public static int GetBookByAuthorCount(string author)
        {
            int count;
            using (var db = new AppContext())
            {
                return count = db.Books.Where(b => b.author == author).Count();
            }
        }

        public static int GetBookByGenreCount(string genre)
        {
            int count;
            using (var db = new AppContext())
            {
                return count = db.Books.Where(b => b.genre == genre).Count();
            }
        }

        public static bool GetBookAvailabilityByAuthorAndTitle(string author, string title)
        {
            bool isBookAvailable;
            using (var db = new AppContext())
            {
                return isBookAvailable = db.Books.Where(b => b.author == author && b.title == title).Any();
            }
        }

        public static Book GetLastPublishedBook()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.publicationDate).First();
            }
        }

        public static List<Book> GetAlphabetListOfBooksByTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(b => b.title).ToList();
            }
        }

        public static List<Book> GetDescendingListOfBooksByPubDate()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.publicationDate).ToList();
            }
        }
    }
}
