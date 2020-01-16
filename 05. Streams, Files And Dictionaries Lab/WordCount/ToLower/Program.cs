using System;

namespace ToLower
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Krasi";
            string b = "krasi";

            if (a.ToLower() == b.ToLower())
            {
                Console.WriteLine(true);
            }
        }
    }
}
