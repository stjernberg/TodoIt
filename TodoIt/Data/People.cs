using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Models;

namespace TodoIt.Data
{
    public class People
    {
       
        private static Person[] personArray = new Person[0];
       
        public Person[] PersonArray
        {
            get
            {
                return personArray;
            }

            set
            {
                personArray = value;
            }
        }


        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll()
        {
            return personArray;
        }

        public Person FindById(int personId)
        {
               
            foreach (Person person in personArray)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        public Person CreateNewPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(firstName, lastName, PersonSequencer.NextPersonId());
            Array.Resize(ref personArray, personArray.Length + 1);
            return newPerson;          
        }

        public void Clear()
        {
            personArray = new Person[0];
        }

        

    }//class
}//namespace
