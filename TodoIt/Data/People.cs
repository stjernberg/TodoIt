using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Models;

namespace TodoIt.Data
{
    public class People
    {
       
        private static Person[] people = new Person[0];
       

        public int Size()
        {
            return people.Length;
        }

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
               
            foreach (Person person in people)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        /*public Person CreateNewPerson()
        {
            Person newPerson = new Person();
¨          
        }*/
    }//class
}//namespace
