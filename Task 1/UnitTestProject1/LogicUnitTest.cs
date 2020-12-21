using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Logic;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using ClassLibrary1.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class LogicUnitTest
    {
        LogicAPI dataContext;

        string randomUserName;
        string randomBook;
        string randomUserName2;
        string randomBook2;
        [TestInitialize]
        public void init()
        {
            //Random string
            randomUserName = Path.GetRandomFileName().Replace(".", "");
            randomBook = Path.GetRandomFileName().Replace(".", "");
            randomUserName2 = Path.GetRandomFileName().Replace(".", "");
            randomBook2 = Path.GetRandomFileName().Replace(".", "");
            //TODO .gitignore
            TestDataRepository testDataRepos = new TestDataRepository(); 
            //TODO DataTestImplementation with own namespace
            Dictionary<int, string> books = new Dictionary<int, string>();
            books.Add(1, randomBook);
            List<string> userNames = new List<string>();
            userNames.Add(randomUserName);
            Dictionary<int, string> borrowedBooks = new Dictionary<int, string>();
            borrowedBooks.Add(2, randomUserName);

            testDataRepos.books = books;
            testDataRepos.users = userNames;
            testDataRepos.borrowedBooks = borrowedBooks;

            dataContext = new DataService(testDataRepos);
        }

        [TestMethod]
        public void addExistingUser()
        {
            try
            {
                dataContext.addUser(randomUserName);
                Assert.IsTrue(false, "A Exception should have been thrown cause the User already exists");
            }
            catch(Exception e)
            {
                Assert.IsTrue(true, "A Exception was thrown cause the User already exists");
            }

        }
        [TestMethod]
        public void addExistingBook()
        {
            try
            {
                dataContext.addBook(randomBook);
                Assert.IsTrue(false, "A Exception should have been thrown cause the Book already exists");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true, "A Exception was thrown cause the Book already exists");
            }
        }
               
        [TestMethod]
        public void borrowNotExistingBook()
        {
            try
            {
                dataContext.borrowBook(randomUserName, 2);
                Assert.IsTrue(false, "A Exception should have been thrown cause the Book does not exists");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true, "A Exception was thrown cause the Book does not exists");
            }
        }
        [TestMethod]
        public void borrowAsNotExistingUser()
        {
            Assert.IsFalse(dataContext.borrowBook(randomUserName2, 1), "A Exception was thrown cause the User does not exists and therefore cant borrow a book");
        }
        [TestMethod]
        public void returnBook()
        {
            Assert.IsTrue(dataContext.returnBook(randomUserName, 2));
        }

        private class TestDataRepository : IDataAPI
        {
            public Dictionary<int, string> books;
            public List<string> users;
            public Dictionary<int,string> borrowedBooks;
            public void addBook(int id, string description)
            {}

            public void addUser(string name)
            {}

            public void borrowBook(int bookId, string nameUser)
            {
            
            }

            public Dictionary<int, string> getAllBooks()
            {
                return books;
            }

            public List<string> getAllUsers()
            {
                return users;    
            }

            public List<int> getAvailableBookIds()
            {
                return new List<int>();
            }

            public string getBook(int id)
            {
                return books[id];
            }

            public Dictionary<int, string> getBorrowedBooksWithNames()
            {
                return borrowedBooks;
            }


            public void returnBook(int bookId, string nameUser)
            {}
        }
    }
}
