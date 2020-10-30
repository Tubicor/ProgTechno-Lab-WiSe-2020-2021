using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    public class DataContext : IDataContext
    {
        private Data.DataRepository repos = new Data.DataRepository();
        public override bool lendBook(string userName,string name)
        {
            return repos.addLendEvent(name, userName);
        }

        public override bool returnBook(string userName, string name)
        {
            return repos.addReturnEvent(name, userName);
        }

        public override Dictionary<string, string> getAllBooks()
        {
            return repos.getAllBooks();
        }

        public override void addBook(string name, string discription)
        {
            repos.addState(name, discription);
        }

        public override void addUser(string name)
        {
            repos.addUser(name);
        }

        public override List<string> getUsers()
        {
            return repos.getUsers();
        }
    }
}
