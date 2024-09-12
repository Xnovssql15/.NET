using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        private Library library = new Library();
        private LibraryMember currentMember;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, System.EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            Book newBook = new Book(title, author, isbn);
            library.AddBook(newBook);
            lstAvailableBooks.Items.Add(newBook);
            ClearBookForm();
        }
        private void ClearBookForm()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
        }

        private void btnBorrowBook_Click(object sender, System.EventArgs e)
        {
            Book selectedBook = lstAvailableBooks.SelectedItem as Book;
            string memberName = txtMemberName.Text;
            string memberId = txtMemberID.Text;
            if (selectedBook != null)
            {
                currentMember = new LibraryMember(memberName, memberId);
                library.AddMember(currentMember);
                currentMember.Borrow(selectedBook);
                lstBorrowedBooks.Items.Add($"{selectedBook} - Borrowed by {currentMember}");
                lstAvailableBooks.Items.Remove(selectedBook);
            }
        }

        private void btnReturnBook_Click(object sender, System.EventArgs e)
        {
            string selectedItem = lstBorrowedBooks.SelectedItem as string;
            if (selectedItem != null)
            {
                Book selectedBook = library.GetBorrowedBooks().FirstOrDefault(b => selectedItem.Contains(b.Title));
                if (selectedBook != null)
                {
                    currentMember.Return(selectedBook);
                    lstAvailableBooks.Items.Add(selectedBook);
                    lstBorrowedBooks.Items.Remove(selectedItem);
                }
            }
        }
    }
}
