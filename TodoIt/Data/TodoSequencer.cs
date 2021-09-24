using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int PersonId
        {
            get
            {
                return todoId;
            }
            set
            {
               todoId = value;
            }
        }
        public TodoSequencer(int personId)
        {
            PersonId = personId;
        }
        public static int NextTodoId()
        {
            todoId++;
            return todoId;
        }


        public static int Reset()
        {
            todoId = 0;
            return todoId;

        }
    }
}

