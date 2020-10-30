using System;
using System.Collections.Generic;
using System.IO;
using ClassLibrary1.Logic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("aa");
            list.Add("bb");
            list.Add("cc");
            list.Add("dd");
            Console.WriteLine(list[list.Count-1]);
        }
    }
}
