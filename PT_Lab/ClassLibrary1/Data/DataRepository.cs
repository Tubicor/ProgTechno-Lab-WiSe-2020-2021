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
    }
}
