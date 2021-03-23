using System;

namespace Bioscoopsysteem.Data
{
    public static class RandomDateGenerator
    {
        public static DateTime RandomDate()
        {
            Random gen = new Random();
            DateTime noon = DateTime.Today.AddHours(12);
            DateTime randomDate = noon.AddHours(gen.Next(10));
            Console.WriteLine(randomDate);
            return randomDate;
        }
    }
}
