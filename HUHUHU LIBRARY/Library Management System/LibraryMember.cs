using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class LibraryMember
    {
        public string Name { get; set; }
        public string MemberID { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public LibraryMember(string name, string memberId)
        {
            Name = name;
            MemberID = memberId;
        }
        public void Borrow(Book book)
        {
            if (book != null && !book.IsBorrowed)
            {
                book.BorrowBook();
                BorrowedBooks.Add(book);
            }
        }
        public void Return(Book book)
        {
            if (book != null && book.IsBorrowed)
            {
                book.ReturnBook();
                BorrowedBooks.Remove(book);
            }
        }
        public override string ToString()
        {
            return $"{Name} (ID: {MemberID})";
        }
    }
}
    