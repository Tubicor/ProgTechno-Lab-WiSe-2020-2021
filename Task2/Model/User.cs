using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User : ModelBase
    {
        private String username;
        private int userId;
        public User( int _userId, String _username)
        {
            username = _username;
            userId = _userId;
        }

        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged("userId");
            }
        }
    }
}
