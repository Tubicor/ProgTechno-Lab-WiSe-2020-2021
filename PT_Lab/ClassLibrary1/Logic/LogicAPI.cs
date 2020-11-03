using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    abstract public class LogicAPI
    {
        protected Data.DataAPI data;
        public LogicAPI(Data.DataAPI _data)
        {
            data = _data;
        }
        abstract public bool lendBook(string userName,string name);
        abstract public bool returnBook(string userName,string name);
        abstract public Dictionary<string, string> getAllBooks();
        abstract public void addBook(string name, string discription);
        abstract public void addUser(string name);
        abstract public List<String> getUsers();
    }
}
