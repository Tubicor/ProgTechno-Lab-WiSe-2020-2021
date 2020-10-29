using System;
using System.Collections.Generic;

namespace ClassLibrary1.Data

{
    class User
    {
        private string name;
        private List<Event> events = new List<Event>();
        public User(string _name){
            name = _name;
        }
        public String getName()
        {
            return name;
        }
        public List<Event> getEvents()
        {
            return events;
        }
    }
}
