using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    public class DataContext
    {
        public State libraryState = new State();
        public List<User> users = new List<User>();
        public List<Event> events = new List<Event>();
        public Catalog books = new Catalog();       
    }
}
