using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod25FinPractice
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int publicationDate { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
