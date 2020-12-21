using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Process : IService
    {
        public Process() : base()
        { }
        public Process(string connectionString) : base(connectionString)
        { }

        #region Book Methods
        override public IEnumerable<Book> getBooks()
        {
            var result = context.Book.ToList();
            return result;
        }

        override public Book getBookById(int _id)
        {

            foreach (Book b in context.Book.ToList())
            {
                if (b.BookId.Equals(_id))
                {
                    return b;
                }
            }
            return null;

        }

        override public Book getBookByTitle(string _title)
        {
            foreach (Book b in context.Book.ToList())
            {
                if (b.Title.Equals(_title))
                {
                    return b;
                }
            }
            return null;
        }

        override public void addBook(string _title)
        {
            int highestBookId = 0;
            if (context.Book.Count() >= 1)
                highestBookId = context.Book.Max(b => b.BookId) + 1;
            Book newBook = new Book
            {
                BookId = highestBookId,
                Title = _title
            };
            context.Book.InsertOnSubmit(newBook);
            context.SubmitChanges();

        }

        override public bool updateBookTitle(int _id, string _title)
        {

            Book book = context.Book.SingleOrDefault(i => i.BookId == _id);
            book.Title = _title;
            context.SubmitChanges();
            return true;

        }

        override public bool deleteBook(string _title)
        {

            Book book = context.Book.FirstOrDefault(i => i.Title == _title);
            context.Book.DeleteOnSubmit(book);
            context.SubmitChanges();
            return true;

        }
        #endregion Methods

        #region Event Methods
        override public IEnumerable<Event> getEvents()
        {
            return context.Event.ToList();

        }

        override public IEnumerable<Event> getEventsForUser(int _userId)
        {
            List<Event> result = new List<Event>();
            foreach (Event e in context.Event)
            {
                if (e.UserId == _userId)
                {
                    result.Add(e);
                }
            }
            return result;

        }

        override public IEnumerable<Event> getEventsForBook(int _bookId)
        {

            List<Event> result = new List<Event>();
            foreach (Event e in context.Event)
            {
                if (e.bookid == _bookId)
                {
                    result.Add(e);
                }
            }
            return result;

        }
        override  public bool addEvent(DateTime _time, string _description, int _bookId, int _userId)
        {

            if (context.User.SingleOrDefault(u => u.UserId.Equals(_userId)) != null &&
                    context.Book.SingleOrDefault(b => b.BookId.Equals(_bookId)) != null)
            {

                int highestEventId = 0;
                if (context.Event.Count() >= 1)
                    highestEventId = context.Event.Max(e => e.EventId)+1;
                Event newEvent = new Event
                {
                    EventId = highestEventId,
                    timestamp = _time,
                    description = _description,
                    bookid = _bookId,
                    UserId = _userId
                };
                context.Event.InsertOnSubmit(newEvent);
                context.SubmitChanges();
                return true;
            }
            return false;

        }

        override public bool deleteEvent(int _userId, int _bookId)
        {

            Event ev = context.Event.FirstOrDefault(e => e.UserId == _userId && e.bookid == _bookId);
            if (ev != null)
            {
                context.Event.DeleteOnSubmit(ev);
                context.SubmitChanges();
                return true;
            }
            return false;

        }

        override public bool updateEventType(int _id, string _description)
        {

            Event ev = context.Event.SingleOrDefault(e => e.EventId == _id);
            ev.description = _description;
            context.SubmitChanges();
            return true;

        }

        #endregion

        #region User Methods
        override public IEnumerable<User> getUsers()
        {
            return context.User.ToList();
        }

        override public User getUserById(int _userId)
        {
            foreach (User u in context.User.ToList())
            {
                if (u.UserId.Equals(_userId))
                {
                    return u;
                }
            }
            return null;
        }

        override public User getUserByName(string _name)
        {
            foreach(User u in context.User.ToList())
            {
                if (u.name.Equals(_name))
                {
                    return u;
                }
            }
            return null;
        }

        override public bool addUser(string _userName)
        {
            int highestUserId = 0;
            if (context.User.Count() >= 1)
                highestUserId = context.User.Max(u => u.UserId) + 1;
            User newUser = new User
            {
                UserId = highestUserId,
                name = _userName
            };
            context.User.InsertOnSubmit(newUser);
            context.SubmitChanges();
            return true;
        }

        override public bool updateUser(int _id, string _name)
        {
                User user = context.User.SingleOrDefault(i => i.UserId == _id);
                user.name = _name;
                context.SubmitChanges();
                return true;
            
        }

        override public bool deleteUser(int _id)
        {
                User reader = context.User.SingleOrDefault(user => user.UserId == _id);
                context.User.DeleteOnSubmit(reader);
                context.SubmitChanges();
                return true;
            
        }

        #endregion
    }
}
