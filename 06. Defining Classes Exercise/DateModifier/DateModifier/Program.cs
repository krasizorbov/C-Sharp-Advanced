using System;
using System.Linq;

namespace Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier dateDifference = new DateModifier();

            int difference = dateDifference.DifferenceBetween2Dates(dateOne, dateTwo);

            Console.WriteLine(difference);
        }
    }

    public class DateModifier
    {
        public int DifferenceBetween2Dates(string dateOne, string dateTwo)
        {
            var date1Arr = dateOne.Split().Select(int.Parse).ToArray();

            DateTime date1 = new DateTime(date1Arr[0], date1Arr[1], date1Arr[2]);

            var date2Arr = dateTwo.Split().Select(int.Parse).ToArray();

            DateTime date2 = new DateTime(date2Arr[0], date2Arr[1], date2Arr[2]);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
