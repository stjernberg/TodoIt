using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Models;

namespace TodoIt.Data
{
    public class TodoItem
    {
        private static Todo[] todoArray = new Todo[0];


        public Todo[] TodoArray
        {
            get
            {
                return todoArray;
            }

            set
            {
                todoArray = value;
            }
        }


        public int Size()
        {
            return todoArray.Length;
        }

        public Todo[] FindAll()
        {
            return todoArray;
        }

        public Todo FindById(int todoId)
        {

            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.TodoId == todoId)
                {
                    return todoItem;
                }
            }
            return null;
        }

        public Todo CreateNewTodo(string description)
        {
            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), description); 
            Array.Resize(ref todoArray, todoArray.Length + 1);            
            todoArray[todoArray.Length - 1] = newTodo;
            return newTodo;
        }

        public void Clear()
        {
            todoArray = new Todo[0];
        }

    }
}
