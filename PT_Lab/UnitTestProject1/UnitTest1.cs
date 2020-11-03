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
    public class UnitTest1
    {
        LogicAPI dataContext;

        string randomUserName;
        string randomBookTitle;
        string randomUserName2;
        string randomBookTitle2;
        [TestInitialize]
        public void init()
        {
            dataContext = new DataContext(new DataRepository());
            randomUserName = Path.GetRandomFileName().Replace(".", "");
            randomBookTitle = Path.GetRandomFileName().Replace(".", "");
            randomUserName2 = Path.GetRandomFileName().Replace(".", "1");
            randomBookTitle2 = Path.GetRandomFileName().Replace(".", "1");
        }

        [TestMethod]
        public void addBooks()
        {
            Dictionary<string, string> bookCatalog = new Dictionary<string, string>();
            //generate random Booknames and Bookdescription (just random strings)
            for (int i = 0; i < 20; i++)
            {
                string title = Path.GetRandomFileName();
                title = title.Replace(".", "");
                string description = Path.GetRandomFileName();
                description = description.Replace(".", "");
                dataContext.addBook(title, description);
                bookCatalog.Add(title, description);
            }

            Assert.IsTrue(dataContext.getAllBooks().SequenceEqual(bookCatalog));
        }
        [TestMethod]
        public void addUsers()
        {
            List<string> users = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                string userName = Path.GetRandomFileName();
                userName = userName.Replace(".", "");

                dataContext.addUser(userName);
                users.Add(userName);
            }
            Assert.IsTrue(users.SequenceEqual(dataContext.getUsers()));
        }
               
        [TestMethod]
        public void lendBookUnregisteredUserAndBook()
        {
            Assert.IsFalse(dataContext.lendBook(randomUserName, randomBookTitle),
                "Can Perform Action on Book, that doesnt exist");
        }
        [TestMethod]
        public void lendBookUnregisteredUser() {
            dataContext.addUser(randomUserName);
            Assert.IsFalse(dataContext.lendBook(randomUserName, randomBookTitle),
                "Can Perform Action on Book for a User that doesnt exist");
        }
        [TestMethod]
        public void lendBook() {
            dataContext.addUser(randomUserName);
            dataContext.addBook(randomBookTitle, "");
            Assert.IsTrue(dataContext.lendBook(randomUserName, randomBookTitle),
                "The book was not lend");
        }
        [TestMethod]
        public void returnUnregisteredBook()
        {
            dataContext.addUser(randomUserName);
            dataContext.addBook(randomBookTitle, "");
            dataContext.lendBook(randomUserName, randomBookTitle);
            Assert.IsFalse(dataContext.returnBook(randomUserName, randomBookTitle2),
                "The returned  was never registered");
        }
        [TestMethod]
        public void returnBookWithoutBeingLent()
        {
            dataContext.addUser(randomUserName);
            dataContext.addBook(randomBookTitle, "");
            dataContext.lendBook(randomUserName, randomBookTitle);
            dataContext.addBook(randomBookTitle2, "");
            Assert.IsFalse(dataContext.returnBook(randomUserName, randomBookTitle2),
                "The returned Book was never lent");
            }
        [TestMethod]
        public void returnBookLentBySomeOtherUser()
        {
            dataContext.addUser(randomUserName);
            dataContext.addBook(randomBookTitle, "");
            dataContext.lendBook(randomUserName, randomBookTitle);
            dataContext.addBook(randomBookTitle2, "");
            dataContext.addUser(randomUserName2);
            dataContext.lendBook(randomUserName2, randomBookTitle2);
            Assert.IsFalse(dataContext.returnBook(randomUserName, randomBookTitle2),
                "The returned Book has not been lend by you");
            }
        [TestMethod]
        public void returnBook()
        {
            dataContext.addUser(randomUserName);
            dataContext.addBook(randomBookTitle, "");
            dataContext.lendBook(randomUserName, randomBookTitle);
            dataContext.addBook(randomBookTitle2, "");
            dataContext.addUser(randomUserName2);
            dataContext.lendBook(randomUserName2, randomBookTitle2);
            Assert.IsTrue(dataContext.returnBook(randomUserName, randomBookTitle),
                "The book was not returend");
        }
    }
}
