using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    abstract public class LogicAPI
    {
        protected Data.IDataAPI data;
        public LogicAPI(Data.IDataAPI _data)
        {
            data = _data;
        }
        abstract public bool borrowBook(string userName,int bookId);
        abstract public bool returnBook(string userName,int bookId);
        abstract public Dictionary<int, string> getAllBooks();
        abstract public List<int> getAvailableBookIds();
        abstract public void addBook(string description);

        abstract public void addUser(string name);
        abstract public List<string> getUsers();
    }
}
