using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Data
{
    public interface IDataAPI
    {
        string getBook(int id);
        Dictionary<int, string> getAllBooks();
        void addBook(int id, string description);
        List<int> getAvailableBookIds();
        Dictionary<int, string> getBorrowedBooksWithNames();

        void addUser(string name);
        List<string> getAllUsers();
        List<string> getUserEvents(string name);

        void borrowBook(int bookId, string nameUser);
        void returnBook(int bookId, string nameUser);

    }
}
