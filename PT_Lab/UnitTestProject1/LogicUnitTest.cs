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
            testDataRepos.books = books;
            testDataRepos.users = userNames;

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
            try
            {
                dataContext.borrowBook(randomUserName2, 1);
                Assert.IsTrue(false, "A Exception should have been thrown cause the User does not exists and therefore cant borrow a book");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true, "A Exception was thrown cause the User does not exists and therefore cant borrow a book");
            }
        }
       
        private class TestDataRepository : IDataAPI
        {
            public Dictionary<int, string> books;
            public List<string> users;
            public void addBook(int id, string description)
            {
                throw new NotImplementedException();
            }

            public void addUser(string name)
            {
                throw new NotImplementedException();
            }

            public void borrowBook(int bookId, string nameUser)
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public string getBook(int id)
            {
                throw new NotImplementedException();
            }

            public Dictionary<int, string> getBorrowedBooksWithNames()
            {
                return new Dictionary<int, string>();
            }

            public List<string> getUserEvents(string name)
            {
                return new List<string>();
            }

            public void returnBook(int bookId, string nameUser)
            {
                throw new NotImplementedException();
            }
        }
    }
}
