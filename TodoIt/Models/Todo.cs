using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Models
{
    public class Todo
    {
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee = new Person();

        public int TodoId
        {
            get
            {
                return todoId;
            }
        }
        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
           
        }

        public string InfoTodo()
        {
            return $"Todo Info\nTodo id: {todoId}\nDescription: {description}";
        }
    }//class

}//namespace
