using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Service
{
    public abstract class IService
    {

        protected DataClasses1DataContext context;
        public IService()
        {
            context = new DataClasses1DataContext();
        }
        public IService(string connectionString)
        {
            context = new DataClasses1DataContext(connectionString);
        }
        #region Book Methods
        public abstract IEnumerable<Book> getBooks();

        public abstract Book getBookById(int _id);
        public abstract Book getBookByTitle(string _title);

        public abstract void addBook(string _title);

        public abstract bool updateBookTitle(int _id, string _title);

        public abstract bool deleteBook(string _title);
        #endregion

        #region Event Methods
        abstract public IEnumerable<Event> getEvents();

        abstract public IEnumerable<Event> getEventsForUser(int _userId);

        abstract public IEnumerable<Event> getEventsForBook(int _bookId);
        abstract public bool addEvent(DateTime _time, string _description, int _bookId, int _userId);

        abstract public bool deleteEvent(int _userId, int _bookId);

        abstract public bool updateEventType(int _id, string _description);
        #endregion

        #region User Methods
        abstract public IEnumerable<User> getUsers();
        abstract public User getUserById(int _userId);
        abstract public User getUserByName(string _name);

        abstract public bool addUser(string _userName);

        abstract public bool updateUser(int _id, string _name);

        abstract public bool deleteUser(int _id);

        #endregion
    }
}

