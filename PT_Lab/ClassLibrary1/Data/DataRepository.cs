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
            Catalog catalog = dataService.getCatalog();
            State state = new State(title,catalog);
            dataService.getStates().Add(state);
            catalog.addState(title,description);

        }
        public string getBookDescritption(string bookName)
        {
            string description;
            if (dataService.getCatalog().getDict().TryGetValue(bookName,out description))
            {
                return description;
            }
            return "Book not Found";

        }
        public Dictionary<string, string> getAllBooks()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            foreach(string bookName in dataService.getCatalog().getDict().Keys)
            {
                dict.Add(bookName, this.getBookDescritption(bookName));
            }
            return dict;
        }
        public bool addLendEvent(string nameBuch, string nameUser)
        {
            State certainBook = this.getBook(nameBuch);
            User certainUser = this.getUser(nameUser);
            if (certainBook == null || !certainBook.isAvailable()|| certainUser == null)
            {
                return false;
            }
            //Book is available to lend
            
            Event e = new LendEvent(certainUser, certainBook);
            e.changeState();
            //Event changes state and adds to user automatically
            return true;

        }
        public bool addReturnEvent(string nameBuch, string nameUser)
        {
            State certainBook = this.getBook(nameBuch);
            User certainUser = this.getUser(nameUser);
            if (certainBook == null || certainBook.isAvailable()||certainUser == null)
            {
                return false;
            }
            //Has the Book been lent by the user
            Event lastEvent = certainBook.getEvents()[certainBook.getEvents().Count-1];
            if (!lastEvent.getUser().getName().Equals(nameUser))
            {
                return false;
            }
            //Book has not been brought back yet and was lent by the user
            
            Event e = new ReturnEvent(certainUser, certainBook);
            e.changeState();
            //Event changes state and adds to user automatically
            return true;

        }
        public List<string> getUsers()
        {
            List<string> userNames = new List<string>();
            foreach(User u in dataService.getUsers())
            {
                userNames.Add(u.getName());
            }
            return userNames;
        }
    }
}
