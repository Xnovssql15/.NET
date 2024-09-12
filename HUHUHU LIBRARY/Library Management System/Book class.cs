using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; } = false;
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
        public void BorrowBook()
        {
            IsBorrowed = true;
        }
        public void ReturnBook()
        {
            IsBorrowed = false;
        }
        public override string ToString()
        {
            return $"{Title} by {Author}, ISBN: {ISBN}";
        }
    }
}
