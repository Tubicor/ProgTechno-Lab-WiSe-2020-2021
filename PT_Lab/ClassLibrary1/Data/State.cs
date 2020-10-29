using System;
using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    class State
    {
        private List<Event> events = new List<Event>();
        private String description;
        private String title;
        private bool state = true;
        public State(String _description, String _title)
        {
            description = _description;
            title = _title;
        }
        public String getDescription()
        {
            return description;
        }
        public String getTitle()
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
    }
}
