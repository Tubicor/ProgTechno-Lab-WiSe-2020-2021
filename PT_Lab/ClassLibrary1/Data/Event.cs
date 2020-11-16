using System;

namespace ClassLibrary1.Data
{
    //TODO description wahrscheinlich nicht benötigt 
    abstract public class Event
    {
        protected User user;
        protected int bookId;
        protected DateTime timestamp;
        protected string description;
        public  Event(User _user,int _bookId,string _description)
        {
            user = _user;
            bookId = _bookId;
            timestamp = DateTime.Now;
            description = _description;
        }
        public User getUser()
        {
            return user;
        }
        public override string ToString()
        {
            return user.name + " has " + this.description + this.bookId + " at " + timestamp.ToString(); 
        }
    }
    public class BorrowEvent : Event
    {
        public BorrowEvent(User _user, int _bookId) :base(_user, _bookId, "lent"){}
    }
    public class ReturnEvent : Event //Bring Back Event
    {
        public ReturnEvent(User _user, int _bookId) : base(_user, _bookId, "brought back") { }
    }
}
