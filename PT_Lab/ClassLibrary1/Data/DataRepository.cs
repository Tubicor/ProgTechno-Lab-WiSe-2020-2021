using System;
using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    class DataRepository
    {
        private DataService dataService = new DataService();
        public User getUser(string name)
        {
            return dataService.getUsers().Find(x => x.getName().Equals(name));
        }
        public State getBook(string title)
        {
            return dataService.getStates().Find(x => x.getTitle().Equals(title));
        }
        public void addUser(string name)
        {
            User user = new User(name);
            dataService.getUsers().Add(user);
        }
        public void addState(string title, string description)
        {
            State state = new State(description, title);
            dataService.getStates().Add(state);
        }
        public string getBookDescritption(string bookName)
        {
            return dataService.getStates().Find(x => x.getTitle().Equals(bookName)).getDescription();
        }
        public Dictionary<string, string> getAllBooks()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            foreach(string bookName in dataService.getCatalog().getDict().Values)
            {
                dict.Add(bookName, this.getBookDescritption(bookName));
            }
            return dict;
        }
        public bool addLendEvent(string nameBuch, string nameUser)
        {
            State certainBook = this.getBook(nameBuch);
            if (!certainBook.isAvailable())
            {
                return false;
            }
            //Book is available to lend
            User certainUser = this.getUser(nameUser);
            new LendEvent(certainUser, certainBook);
            //Event changes state and adds to user automatically
            return true;

        }
        public bool addBringBackEvent(string nameBuch, string nameUser)
        {
            State certainBook = this.getBook(nameBuch);
            if (certainBook.isAvailable())
            {
                return false;
            }
            //Book has not been brought back yet
            User certainUser = this.getUser(nameUser);
            new BringBackEvent(certainUser, certainBook);
            //Event changes state and adds to user automatically
            return true;

        }
    }
}
