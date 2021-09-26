using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int TodoId
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
            TodoId = personId;
        }
        public static int NextTodoId()
        {
            todoId++;
            return todoId;
        }


        public static void Reset()
        {
            todoId = 0;
            
        }
    }
}

