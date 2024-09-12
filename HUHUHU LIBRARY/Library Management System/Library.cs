using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<LibraryMember> Members { get; set; } = new List<LibraryMember>();
        public void AddBook(Book book)
        {
            if (book != null)
                Books.Add(book);
        }
        public void AddMember(LibraryMember member)
        {
            if (member != null)
                Members.Add(member);
        }
        public List<Book> GetAvailableBooks()
        {
            return Books.Where(b => !b.IsBorrowed).ToList();
        }
        public List<Book> GetBorrowedBooks()
        {
            return Books.Where(b => b.IsBorrowed).ToList();
        }
    }
}
