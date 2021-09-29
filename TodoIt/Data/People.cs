using System;
using TodoIt.Models;

namespace TodoIt.Data
{
    //testing
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
            personArray[personArray.Length - 1] = newPerson;
            return newPerson;
        }

        public void Clear()
        {
            personArray = new Person[0];
        }


        public void RemovePerson(int id)
        {

            for (int i = 0; i < personArray.Length; i++)
            {
                if (personArray[i].PersonId == id)
                {

                    for (int offset = i + 1; offset < personArray.Length; offset++, i++)
                    {
                        personArray[i] = personArray[offset];
                    }
                    Array.Resize(ref personArray, personArray.Length - 1);
                    break;
                }
            }
        }
        

    }//class
}//namespace
