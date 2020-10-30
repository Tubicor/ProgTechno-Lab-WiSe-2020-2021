using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    abstract class IDataContext
    {
        abstract public void login(String userName);
        abstract public void logout();
        abstract public bool lendBook(String name);
        abstract public bool returnBook(String name);
        abstract public Dictionary<String, String> getAllBooks();
        abstract public void addBook(String name, String discription);
        abstract public void addUser(String name);
    }
}
