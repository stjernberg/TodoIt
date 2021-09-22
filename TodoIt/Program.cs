using System;
using TodoIt.Models;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person theperson = new Person();
            Person testPerson = new Person(1, "William", "Smith");
            Console.WriteLine(testPerson.Info());

        }
    }
}
