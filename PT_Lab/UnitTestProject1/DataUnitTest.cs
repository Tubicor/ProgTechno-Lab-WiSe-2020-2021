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
    public class DataUnitTest
    {
        IDataAPI dataRepos;
        [TestInitialize]
        public void init()
        {
            dataRepos = new DataRepository(new DataContext());
        }

        [TestMethod]
        public void addBooks()
        {
            Dictionary<int, string> bookCatalog = new Dictionary<int, string>();
            Random rnd = new Random();
            int id = 0;
            for (int i = 0; i < 20; i++)
            {
                string description = Path.GetRandomFileName().Replace(".", "");
                id += rnd.Next(1,5);
                dataRepos.addBook(id, description);
                bookCatalog.Add(id, description);
            }
            Assert.IsTrue(dataRepos.getAllBooks().SequenceEqual(bookCatalog));
        }
        [TestMethod]
        public void addUsers()
        {
            List<string> users = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                string name = Path.GetRandomFileName().Replace(".", "");
                dataRepos.addUser(name);
                users.Add(name);
            }
            Assert.IsTrue(dataRepos.getAllUsers().SequenceEqual(users));
        }
               
        [TestMethod]
        public void makeBookUnavailable()
        {
            string randomUser = Path.GetRandomFileName().Replace(".", "");
            string randomBook = Path.GetRandomFileName().Replace(".", "");
            Random rnd = new Random();
            int randomId = rnd.Next(1000, 2000);
            dataRepos.addUser(randomUser);
            dataRepos.addBook(randomId,randomBook);
            dataRepos.borrowBook(randomId, randomUser);

            Assert.IsFalse(dataRepos.getAvailableBookIds().Contains(randomId));
        }
    }
}
