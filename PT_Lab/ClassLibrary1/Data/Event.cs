using System;

namespace ClassLibrary1.Data
{
    //TODO description wahrscheinlich nicht benötigt
    abstract public class Event
    {
        protected User user;
        protected State state;
        protected DateTime timestamp;
        protected string description;
        public  Event(User _user,State _state,string _description)
        {
            user = _user;
            state = _state;
            timestamp = DateTime.Now;
            description = _description;
        }
        abstract public void changeState();
        public User getUser()
        {
            return user;
        }
    }
    class LendEvent : Event
    {
        public LendEvent(User _user,State _state):base(_user,_state,"lent"){}

        public override  void changeState(){
            user.addEvent(this);
            state.addEvent(this);
            //set state to not available anymore
            state.setState(false);
        }
    }
    class ReturnEvent : Event //Bring Back Event
    {
        public ReturnEvent(User _user, State _state) : base(_user, _state,"brought back") { }

        public override void changeState()
        {
            user.addEvent(this);
            state.addEvent(this);
            //set state to available again
            state.setState(true);
        }
    }
}
