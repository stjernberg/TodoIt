using System;
using TodoIt.Data;
using TodoIt.Models;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Person theperson = new Person();
            Person testPerson = new Person(1, "William", "Smith");
            Todo testTodo = new Todo(4, "shop");
            PersonSequencer testSequencer = new PersonSequencer(2);
            Console.WriteLine(testPerson.InfoPerson());
            Console.WriteLine(testTodo.InfoTodo());

        }
    }
}
