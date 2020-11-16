using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    public class DataService : LogicAPI
    {
        private int maxBookId = 1;
        public DataService(Data.IDataAPI _data) : base(_data)
        {
        }
        public override void addBook(string description)
        {
            //does book already exist?
            if (data.getAllBooks().ContainsValue(description))
            {
                throw new System.Exception("Book with this discription already exists in library");
            }
            data.addBook(maxBookId++, description);
        }

        public override void addUser(string name)
        {
            //does user already exist?
            if (data.getAllUsers().Contains(name))
            {
                throw new System.Exception("User does not exist");
            }
            throw new NotImplementedException();
        }

        public override bool borrowBook(string userName, int bookId)
        {
            //does user exist?
            if (!data.getAllUsers().Contains(userName))
            {
                throw new System.Exception("User does not exist");
            }
            //is book borrowed?
            if (!data.getBorrowedBooksWithNames().ContainsKey(bookId))
            {
                throw new System.Exception("Book is not available");
            }
            data.borrowBook(bookId, userName);
            return true;
        }
        public override bool returnBook(string userName, int bookId)
        {
            //does user exist?
            if (!data.getAllUsers().Contains(userName))
            {
                throw new System.Exception("User does not exist");
            }
            //is book borrowed?
            if (!data.getBorrowedBooksWithNames().ContainsKey(bookId))
            {
                throw new System.Exception("Book is not available");
            }
            //is book borrowed by user?
            if(!data.getBorrowedBooksWithNames()[bookId].Equals(userName))
            {
                throw new System.Exception("Book was borrowed by another user");
            }
            data.returnBook(bookId, userName);
            return true;
        }
        public override Dictionary<int, string> getAllBooks()
        {
            return data.getAllBooks();
        }

        public override List<int> getAvailableBookIds()
        {
            return data.getAvailableBookIds();
        }

        public override List<string> getUsers()
        {
            return data.getAllUsers();
        }        
    }
}
