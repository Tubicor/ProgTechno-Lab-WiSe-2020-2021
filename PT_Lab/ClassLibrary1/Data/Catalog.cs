using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    class Catalog
    {
        private Dictionary<State,string> dictonary = new Dictionary<State,string>();

        public void addState(State _state)
        {
            dictonary.Add(_state,_state.getTitle());
        }
        public Dictionary<State, string> getDict()
        {
            return dictonary;
        }
    }
}
