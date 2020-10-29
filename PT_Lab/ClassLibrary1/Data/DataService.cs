using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    class DataService
    {
        private List<State> states = new List<State>();
        private List<User> users = new List<User>();
        private List<Event> events = new List<Event>();
        private Catalog catalog = new Catalog();
        public List<State> getStates()
        {
            return states;
        }
        public List<User> getUsers()
        {
            return users;
        }
        public List<Event> getEvents()
        {
            return events;
        }
        public Catalog getCatalog()
        {
            return catalog;
        }
    }
}
