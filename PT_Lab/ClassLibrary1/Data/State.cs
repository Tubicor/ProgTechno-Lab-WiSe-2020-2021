using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace ClassLibrary1.Data
{
    public class State
    {
        private List<Event> events = new List<Event>();
        private string title;
        private bool state = true;
        private Catalog catalog;
        public State(string _title,Catalog _catalog)
        {
            catalog = _catalog;
            title = _title;
        }
        public string getTitle()
        {
            return title;
        }
        public void setState(bool _state)
        {
            state = _state;
        }
        public bool isAvailable()
        {
            return state;
        }
        public void addEvent(Event e)
        {
            events.Add(e);
        }
        public List<Event> getEvents()
        {
            return events;
        }
    }
}
