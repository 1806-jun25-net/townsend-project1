using PizzaStore.Library;
using System;

namespace PizzaStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string last = Console.ReadLine();
            EndUser user = new EndUser(first, last);

        }
    }
}
