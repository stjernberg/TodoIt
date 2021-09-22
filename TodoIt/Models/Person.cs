using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Models
{
    public class Person
    {
        private readonly int personId;
        private string firstName;
        private string lastName;

        /*public Person()
        {

        }*/


        public string FirstName
        {
            get
            {
                return firstName;
            }


            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname can't be null or empty.");
                }

                else
                {
                    firstName = value;
                }
            }


        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lastname can't be null or empty.");
                }

                else
                {
                    lastName = value;
                }
            }

        }

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
        //testing the info
        public string Info()
        {
            return $"Person Info:\n First name: {firstName}\nLast name: {lastName}\nPerson Id: {personId}";
        }


    }//class
}//namespace
