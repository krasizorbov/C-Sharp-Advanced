using System;
using System.Linq;

namespace CountUpperCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filterUppercase = s => Char.IsUpper(s[0]);

            Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(filterUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
