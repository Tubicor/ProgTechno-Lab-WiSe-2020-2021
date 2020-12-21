using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Event: ModelBase
    {
        private int eventId;
        private int userId;
        private int bookId;
        private DateTime timestamp;
        private string description;

        public Event(int _eventId, int _userId, int _bookId, DateTime _timestamp, string _description)
        {
            eventId = _eventId;
            userId = _userId;
            bookId = _bookId;
            timestamp = _timestamp;
            description = _description;
        }
        public int EventId
        {
            get 
            {
                return eventId;
            }
            set 
            {
                eventId = value;
                OnPropertyChanged("eventId");
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
        public int BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                OnPropertyChanged("bookId");
            }
        }
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
                OnPropertyChanged("timestamp");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("description");
            }
        }
    }
}
