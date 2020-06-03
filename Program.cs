using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Lab3DS
{
    class Program
    {
        static private long PreHash(string str)
        {
            long hash = 5381;
            foreach (var c in str)
                hash = ((hash << 5) + hash) + c; /* hash * 33 + c */
            return hash;
        }
        static void Main(string[] args)
        {
            Dictionary dict = new Dictionary();
            var fname = "dict_processed.txt";
            dict.ParseTxt(fname);
            Console.WriteLine("Input word:");

            Console.WriteLine(dict[Console.ReadLine()]);
        }
    }
}
