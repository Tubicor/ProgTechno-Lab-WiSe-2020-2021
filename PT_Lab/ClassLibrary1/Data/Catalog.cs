using System.Collections.Generic;

namespace ClassLibrary1.Data
{
    public class Catalog
    {
        private Dictionary<string,string> dictonary = new Dictionary<string, string>();

        public void addState(string _bookTitle, string _description)
        {
            dictonary.Add(_bookTitle, _description);
        }
        public Dictionary<string, string> getDict()
        {
            return dictonary;
        }
    }
}
