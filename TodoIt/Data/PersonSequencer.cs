using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{

    public class PersonSequencer
    {
        private static int personId;

        public static int PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
            }
        }
        public PersonSequencer(int personId)
        {
            PersonId = personId;
        }
        public static int NextPersonId()          
        {
             personId ++;
             return personId;
         }


        public static int Reset()
        {
            personId = 0;
            return personId;
            
        }
    }
}
