using System;

namespace ClassLibrary1.Data
{
    //TODO description wahrscheinlich nicht benötigt
    abstract class Event
    {
        private User user;
        private State state;
        private DateTime timestamp;
        private string description;
        public Event(User _user,State _state,string _description)
        {
            user = _user;
            state = _state;
            timestamp = DateTime.Now;
            description = _description;
        }
        abstract public void changeState();
    }
    class LendEvent : Event
    {
        public LendEvent(User _user,State _state):base(_user,_state,"lent"){}

        public override void changeState(){
            throw new System.Exception("Lend TBD");
        }
    }
    class GiveBack : Event
    {
        public GiveBack(User _user, State _state) : base(_user, _state,"brought back") { }

        public override void changeState()
        {
            throw new System.Exception("Give back TBD");
        }
    }
}
