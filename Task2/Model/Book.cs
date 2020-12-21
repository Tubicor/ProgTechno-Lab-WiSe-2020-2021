using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Book: ModelBase
    {
        private int bookId;
        private string title;

        public Book(int _bookId,string _title)
        {
            bookId = _bookId;
            title = _title;
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
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("title");
            }
        }

    }
}
