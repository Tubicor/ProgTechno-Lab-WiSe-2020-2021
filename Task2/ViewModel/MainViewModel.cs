using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;
using System.IO;
using System.Windows.Input;
using System.Linq;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IService service;
        public MainViewModel() : this(new Process()){}
        public MainViewModel(IService _service )
        {
            //service to load and store Models
            service = _service;
            //Commands
            ////User
            RefreshUsers = new Command(refreshUsers);
            UpdateUser = new Command(updateUser);
            AddUser = new Command(addUser, canAddUser);
                NewUser = new User(0, "New User");
            ////Event
            RefreshEvents = new Command(refreshEvents, canRefresh);
            AddGiveBackEvent = new Command(addGiveBackEvent,canGiveBack);
            AddLendEvent = new Command(addLendEvent,canLend);
            ////Book
            RefreshBooks = new Command(refreshBooks);
            AddBook = new Command(addBook, canAddBook);
                NewBook = new Book(0, "New Book");
        }

        #region User
        private IEnumerable<User> users;
        public IEnumerable<User> Users
        {
            get => this.users;

            set
            {
                this.users = value;
                OnPropertyChanged("Users");
            }
        }
        public Command RefreshUsers
        {
            get; private set;
        }
        private void refreshUsers()
        {
            Task.Run(() => this.users = loadUsers());
        }
        private IEnumerable<User> loadUsers()
        {
            List<User> users = new List<User>();
            foreach (Data.User u in service.getUsers())
            {
                users.Add(new Model.User(u.UserId, u.name));
            }
            return users;
        }
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return this.currentUser;
            }

            set
            {
                this.currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        public Command UpdateUser
        {
            get; private set;
        }
        private void updateUser()
        {
            service.updateUser(currentUser.UserId, currentUser.Username);
        }
        private User newUser;
        public User NewUser
        {
            get
            {
                return this.newUser;
            }

            set
            {
                this.newUser = value;
                OnPropertyChanged("NewUser");
            }
        }
        public Command AddUser
        {
            get;private set;
        }
        private void addUser()
        {
            service.addUser(newUser.Username);
            newUser = new User(0, "New User");
            refreshUsers();
        }
        private bool canAddUser()
        {
            if(newUser == null)
            {
                return false;
            }
            return !String.IsNullOrWhiteSpace(newUser.Username);           
        }
        #endregion

        #region Event
        private IEnumerable<Event> events;
        public IEnumerable<Event> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }
        public Command RefreshEvents
        {
            get;private set;
        }
        private void refreshEvents()
        {
            Task.Run(() => this.events = loadEvents());
        }
        private IEnumerable<Event> loadEvents()
        {
            List<Event> events = new List<Event>();
            if (currentUser != null)
            {
                foreach (Data.Event e in service.getEventsForUser(currentUser.UserId))
                {
                    events.Add(new Event(e.EventId, e.UserId, e.bookid, e.timestamp, e.description));
                }
                return events;
            }
            return events;
        }
        private bool canRefresh()
        {
            return currentUser != null;
        }
        private Event currentEvent;
        public Event CurrentEvent
        {
            get
            {
                return currentEvent;
            }
            set
            {
                currentEvent = value;
                service.updateEventType(currentEvent.EventId, currentEvent.Description);
                OnPropertyChanged("CurrentEvent");
            }
        }
        public Book BookFromEvent
        {
            get
            {
                if (books != null)
                {
                    foreach (Book b in books)
                    {
                        if (currentEvent.BookId == b.BookId)
                            return b;
                    }
                }
                return new Book(0, "");
            }
        }
        public Command AddGiveBackEvent
        {
            get;private set;
        }
        private void addGiveBackEvent()
        {
            service.addEvent(DateTime.Now, "brought back", currentBook.BookId ,currentUser.UserId);
        }
        private bool canGiveBack()
        {
            if (events != null)
            {
                foreach (Event e in events)
                {
                    if (e.BookId == currentBook.BookId)
                        if (e.Description.Equals("borrowed"))
                            return true;
                        else
                            return false;

                }
            }
            return false;
        }
        public Command AddLendEvent
        {
            get; private set;
        }
        private void addLendEvent()
        {
            service.addEvent(DateTime.Now, "lent", currentBook.BookId, currentUser.UserId);
        }
        private bool canLend()
        {
            if (events != null)
            {
                foreach (Event e in events)
                {
                    if (e.BookId == currentBook.BookId)
                        if (e.Description.Equals("borrowed"))
                            return false;
                        else
                            return true;

                }
                return true;
            }
            return false;
        }
        #endregion
 
        #region Books
        private IEnumerable<Book> books;
        public IEnumerable<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                this.books = value;
                OnPropertyChanged("Books");
            }
        }
        public Command RefreshBooks
        {
            get; private set;
        }
        private void refreshBooks()
        {
            Task.Run(() => this.books = loadBooks());
        }
        private IEnumerable<Book> loadBooks()
        {
            List<Book> books = new List<Book>();
            foreach(Data.Book b in service.getBooks())
            {
                books.Add(new Book(b.BookId, b.Title));
            }
            return books;
        }
        private Book currentBook;
        public Book CurrentBook
        {
            get
            {
                return currentBook;
            }
            set
            {
                this.currentBook = value;
                OnPropertyChanged("CurrentBook");
            }
        }
        private Book newBook;
        public Book NewBook
        {
            get
            {
                return this.newBook;
            }

            set
            {
                this.newBook = value;
                OnPropertyChanged("NewBook");
            }
        }
        public Command AddBook
        {
            get; private set;
        }
        private void addBook()
        {
            service.addBook(newBook.Title);
            newUser = new User(0, "New Book");
            refreshBooks();
        }
        private bool canAddBook()
        {
            if (newBook == null)
            {
                return false;
            }
            return !String.IsNullOrWhiteSpace(newBook.Title);
        }
        #endregion
    }
}
