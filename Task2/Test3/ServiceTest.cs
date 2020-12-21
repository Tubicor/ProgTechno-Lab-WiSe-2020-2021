using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Data;
using Test.Instrumentation;
using Service;
using System.Linq;

namespace Test
{

    [TestClass]
    [DeploymentItem(@"Instrumentation\DataRepository.mdf", @"Instrumentation")]
    public class ServiceTest
    {
        #region instrumentation
        // Connection string defined in LinqToSqlLibTests project settings.
        private static string m_ConnectionString;
        private static IService service;
        #endregion
        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"Instrumentation\DataRepository.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
            service = new Process(m_ConnectionString);
        }
        [TestMethod]
        public void testAddBook()
        {
            string randomTitle = GenerateRandom.RandomString(20);
            Assert.IsNull(service.getBookByTitle(randomTitle));
            service.addBook(randomTitle);
            Assert.IsNotNull(service.getBookByTitle(randomTitle));
            Assert.IsTrue(service.getBookByTitle(randomTitle).Title.Equals(randomTitle));
        }
        [TestMethod]
        public void testUpdateUser()
        {
            string randomName = GenerateRandom.RandomString(20);
            string randomName2 = GenerateRandom.RandomString(20);
            service.addUser(randomName);
            Assert.IsNotNull(service.getUserByName(randomName));
            Assert.IsNull(service.getUserByName(randomName2));
            service.updateUser(service.getUserByName(randomName).UserId, randomName2);
            Assert.IsNull(service.getUserByName(randomName));
            Assert.IsNotNull(service.getUserByName(randomName2));
        }
        [TestMethod]
        public void testDeleteEvent()
        {
            string randomName = GenerateRandom.RandomString(20);
            string randomTitle = GenerateRandom.RandomString(20);
            service.addUser(randomName);
            service.addBook(randomTitle);
            int idBook = service.getBookByTitle(randomTitle).BookId;
            int idUser = service.getUserByName(randomName).UserId;
            service.addEvent(DateTime.Now,"borrowed",idBook, idUser);
            Assert.IsTrue(service.getEventsForBook(idBook).ToList().Count() == 1);
            Assert.IsTrue(service.getEventsForUser(idUser).ToList().Count() == 1);
            service.deleteEvent(idUser, idBook);
            Assert.IsTrue(service.getEventsForBook(idBook).ToList().Count() == 0);
            Assert.IsTrue(service.getEventsForUser(idUser).ToList().Count() == 0);
        }
    }
}
