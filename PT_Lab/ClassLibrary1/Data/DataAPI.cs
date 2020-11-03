using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Data
{
    abstract public class DataAPI
    {
        public abstract User getUser(string name);

        public abstract State getBook(string title);

        public abstract void addUser(string name);

        public abstract void addState(string title, string description);

        public abstract string getBookDescritption(string bookName);

        public abstract Dictionary<string, string> getAllBooks();

        public abstract bool addLendEvent(string nameBuch, string nameUser);

        public abstract bool addReturnEvent(string nameBuch, string nameUser);

        public abstract List<string> getUsers();
    }
}
