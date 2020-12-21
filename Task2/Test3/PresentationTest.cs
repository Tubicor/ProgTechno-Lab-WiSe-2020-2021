using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;
using Test.Instrumentation;
using System.Threading.Tasks;

using ViewModel;
using Data;
using System.Threading;

namespace Test
{
    [TestClass]
    public class PresentationTest
    {
        public static MainViewModel viewModel;
        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            viewModel = new MainViewModel(new TestProcess());
            Assert.IsNull(viewModel.Books);
            Assert.IsNull(viewModel.Users);
            Assert.IsNull(viewModel.Events);
            Assert.IsNull(viewModel.CurrentEvent);
            Assert.IsNull(viewModel.CurrentUser);
            Assert.IsNull(viewModel.CurrentBook);

            Assert.IsNotNull(viewModel.AddBook);
            Assert.IsNotNull(viewModel.AddGiveBackEvent);
            Assert.IsNotNull(viewModel.AddLendEvent);
            Assert.IsNotNull(viewModel.AddUser);
            viewModel.RefreshBooks.Execute(null);
            viewModel.RefreshEvents.Execute(null);
            viewModel.RefreshUsers.Execute(null);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void addAndUpdate()
        {
            Assert.IsTrue(viewModel.Books.ToList().Count() == 0);
            viewModel.NewBook.Title = GenerateRandom.RandomString(20);
            viewModel.AddBook.Execute(null);
            Thread.Sleep(1000);
            Assert.IsTrue(viewModel.Books.ToList().Count() == 1);

            Assert.IsTrue(viewModel.Users.ToList().Count() == 0);
            viewModel.NewUser.Username = GenerateRandom.RandomString(20);
            viewModel.AddUser.Execute(null);
            Thread.Sleep(1000);
            Assert.IsTrue(viewModel.Users.ToList().Count() == 1);

            Assert.IsTrue(viewModel.Events.ToList().Count() == 0);
            viewModel.CurrentBook = viewModel.Books.First();
            viewModel.CurrentUser = viewModel.Users.First();
            viewModel.AddLendEvent.Execute(null);
            Thread.Sleep(1000);
            viewModel.RefreshEvents.Execute(null);

            Thread.Sleep(1000);
            Assert.IsTrue(viewModel.Events.ToList().Count() == 1);

            viewModel.CurrentEvent = viewModel.Events.First();
            string rndDiscription = GenerateRandom.RandomString(20);
            viewModel.CurrentEvent.Description = rndDiscription;
            viewModel.CurrentEvent = viewModel.CurrentEvent;
            Thread.Sleep(1000);
            viewModel.RefreshEvents.Execute(null);
            Thread.Sleep(1000);
            Assert.IsTrue(viewModel.Events.First().Description.Equals(rndDiscription));
        }

    }
    public class TestProcess: IService
    {
        Random rnd = new Random();
        List<Book> books = new List<Book>();
        List<User> users = new List<User>();
        List<Event> events = new List<Event>();
        public override void addBook(string _title)
        {
            Book book = new Book();
            book.BookId = rnd.Next();
            book.Title = _title;
            books.Add(book);
        }

        public override bool addEvent(DateTime _time, string _description, int _bookId, int _userId)
        {
            Event evnt = new Event { Book = getBookById(_bookId), description = _description, timestamp = _time, User = getUserById(_userId)};           
            events.Add(evnt);
            return true;
        }

        public override bool addUser(string _userName)
        {
            User user = new User{ Event = null, name = _userName};
            users.Add(user);
            return true;
        }

        public override bool deleteBook(string _title)
        {
            throw new NotImplementedException();
        }

        public override bool deleteEvent(int _userId, int _bookId)
        {
            throw new NotImplementedException();
        }

        public override bool deleteUser(int _id)
        {
            throw new NotImplementedException();
        }

        public override Book getBookById(int _id)
        {
            return books.Find(b => b.BookId == _id);
        }

        public override Book getBookByTitle(string _title)
        {
            return books.Find(b => b.Title == _title);
        }

        public override IEnumerable<Book> getBooks()
        {
            return books;
        }

        public override IEnumerable<Event> getEvents()
        {
            return events;
        }

        public override IEnumerable<Event> getEventsForBook(int _bookId)
        {
            return events.FindAll(e => e.bookid == _bookId);
        }

        public override IEnumerable<Event> getEventsForUser(int _userId)
        {
            return events.FindAll(e => e.UserId == _userId);
        }

        public override User getUserById(int _userId)
        {
            return users.Find(u => u.UserId == _userId);
        }

        public override User getUserByName(string _name)
        {
            return users.Find(u => u.name.Equals( _name));
        }

        public override IEnumerable<User> getUsers()
        {
            return users;
        }

        public override bool updateBookTitle(int _id, string _title)
        {
            Book book = books.Find(b => b.BookId == _id);
            if (book == null)
                return false;
            book.Title = _title;
            return true;
        }

        public override bool updateEventType(int _id, string _description)
        {
            Event evnt = events.Find(e => e.EventId == _id);
            if (evnt == null)
                return false;
            evnt.description = _description;
            return true;
        }

        public override bool updateUser(int _id, string _name)
        {
            User user = users.Find(u => u.UserId == _id);
            if (user == null)
                return false;
            user.name = _name;
            return true;
        }
    }
}
