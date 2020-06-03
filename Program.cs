using System;
using System.Threading;

namespace Lab3DS
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = DateTime.Now;

            Dictionary dict = new Dictionary();
            dict["meme13212"] = "123123123boiiiiiii";
            dict["meme"] = "boiiiiiii";
            Console.WriteLine(dict["meme"]);
            dict["asdsdasd"] = "lorem ipsum";
            dict["meme13212"] = "123123123boiiiiiii";
            dict["meme"] = "dank bro";
            for (int i = 0; i < 1000000; i++)
            {
                dict[i.ToString()] = "i" + 123 + i.ToString();
            }
            var b = DateTime.Now;            
            Console.WriteLine(dict["meme"]);
            Console.WriteLine(DateTime.Now - b);
            Console.WriteLine();
            Console.WriteLine(DateTime.Now - a);
            
        }
    }
}
