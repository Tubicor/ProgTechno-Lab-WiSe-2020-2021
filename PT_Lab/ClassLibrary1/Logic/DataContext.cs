using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    class DataContext : IDataContext
    {
        private string activeUser = null;
        private Data.DataRepository repos = new Data.DataRepository();
        public override void login(string userName)
        {
            activeUser = userName;
        }

        public override void logout()
        {
            activeUser = null;
        }

        public override bool lendBook(string name)
        {
            checkLoggedUser();
            return repos.addLendEvent(name, activeUser);
        }

        public override bool returnBook(string name)
        {
            checkLoggedUser();
            return repos.addBringBackEvent(name,activeUser);
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
        public void checkLoggedUser()
        {
            if (activeUser == null)
            {
                throw new Exception("kein User angemeldet");
            }
        }
    }
}
