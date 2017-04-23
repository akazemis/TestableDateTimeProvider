using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableDateTimeProvider;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Current Utc Date: {DateTimeProvider.Instance.GetUtcNow()}");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }
    }
}
