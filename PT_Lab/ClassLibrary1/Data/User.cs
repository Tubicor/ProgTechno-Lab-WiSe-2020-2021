using System;
using System.Collections.Generic;

namespace ClassLibrary1.Data

{
    public class User
    {
        public string name { get; }
        public List<Event> events { get; set; } = new List<Event>();
        public User(string _name){
            name = _name;
        }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || !(obj is User))
        //    {
        //        return false;
        //    }

        //    User reader = (User)obj;
        //    return 
        //}
    }
}
