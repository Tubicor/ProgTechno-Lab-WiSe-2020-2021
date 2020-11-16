using System;
using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    public class DataRepository : IDataAPI
    {
        private DataContext dataContext;

        public DataRepository(DataContext _context)
        {
            this.dataContext = _context;
        }
        public string getBook(int id)
        {
            if (!dataContext.books.dictonary.ContainsKey(id)) {
                throw new System.Exception("Book not existing");
            }
            return dataContext.books.dictonary[id]; 
        }

        public Dictionary<int, string> getAllBooks()
        {
            return dataContext.books.dictonary;
        }

        public void addBook(int id, string description)
        {
            if (dataContext.books.dictonary.ContainsKey(id))
            {
                throw new System.Exception("Book with id already existing");
            }
            dataContext.books.dictonary.Add(id, description);
        }

        public void addUser(string name)
        {
            if (null != dataContext.users.Find(x => x.name.Equals(name)))
            {
                throw new System.Exception("User with that name already exists");
            }
            dataContext.users.Add(new User(name));
        }

        public List<string> getUserEvents(string name)
        {
            User user = dataContext.users.Find(x => x.name.Equals(name));
            if(user == null)
            {
                throw new System.Exception("User does not exist");
            }
            List<string> events = new List<string>();
            foreach(Event e in dataContext.events)
            {
                events.Add(e.ToString());
            }
            return events;
        }

        public void borrowBook(int bookId, string nameUser)
        {
            User user = dataContext.users.Find(x => x.name.Equals(nameUser));            
            Event e = new BorrowEvent(user, bookId);
            dataContext.libraryState.bookStates[bookId] = e;
            user.events.Add(e);
        }

        public void returnBook(int bookId, string nameUser)
        {
            User user = dataContext.users.Find(x => x.name.Equals(nameUser));         
            Event returnEvent = new ReturnEvent(user, bookId);
            dataContext.libraryState.bookStates[bookId] = null;
            user.events.Add(returnEvent);
        }

        public List<int> getAvailableBookIds()
        {
            List<int> availableBookIds = new List<int>();
            foreach(KeyValuePair<int,Event> aBook in dataContext.libraryState.bookStates)
            {
                //if no event is saved for this book then it must be available
                if (aBook.Value == null) {
                    availableBookIds.Add(aBook.Key);
                }
            }
            return availableBookIds;
        }

        public List<string> getAllUsers()
        {
            List<string> userNames = new List<string>();
            foreach(User u in dataContext.users)
            {
                userNames.Add(u.name);
            }
            return userNames;
        }

        public Dictionary<int, string> getBorrowedBooksWithNames()
        {
            Dictionary<int, string> borrowedBooks = new Dictionary<int, string>();
            foreach(KeyValuePair<int,Event> book in dataContext.libraryState.bookStates)
            {
                if(book.Value != null)
                {
                    borrowedBooks.Add(book.Key, book.Value.getUser().name);
                }
            }
            return borrowedBooks;
        }
    }
}
