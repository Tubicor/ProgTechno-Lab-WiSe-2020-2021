using System;
using System.Collections.Generic;

namespace ClassLibrary1.Logic
{
    public class DataContext : LogicAPI
    {
        public DataContext(Data.DataAPI _data) : base(_data)
        {

        }
        public override bool lendBook(string userName,string name)
        {
            return data.addLendEvent(name, userName);
        }

        public override bool returnBook(string userName, string name)
        {
            return data.addReturnEvent(name, userName);
        }

        public override Dictionary<string, string> getAllBooks()
        {
            return data.getAllBooks();
        }

        public override void addBook(string name, string discription)
        {
            data.addState(name, discription);
        }

        public override void addUser(string name)
        {
            data.addUser(name);
        }

        public override List<string> getUsers()
        {
            return data.getUsers();
        }
    }
}
