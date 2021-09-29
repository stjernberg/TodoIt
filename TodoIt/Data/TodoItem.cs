using System;
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
            Todo newTodo = new Todo(description, TodoSequencer.NextTodoId());
            Array.Resize(ref todoArray, todoArray.Length + 1);
            todoArray[todoArray.Length - 1] = newTodo;
            return newTodo;
        }

        public void Clear()
        {
            todoArray = new Todo[0];
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] filteredArray = new Todo[0];
            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Done == doneStatus)
                {
                    Array.Resize(ref filteredArray, filteredArray.Length + 1);
                    filteredArray[filteredArray.Length - 1] = todoItem;
                }
            }
            return filteredArray;
        }
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] filteredArray = new Todo[0];
            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Assignee != null)
                {
                    if (todoItem.Assignee.PersonId == personId)
                    {
                        Array.Resize(ref filteredArray, filteredArray.Length + 1);
                        filteredArray[filteredArray.Length - 1] = todoItem;
                    }
                }

            }
            return filteredArray;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] filteredArray = new Todo[0];

            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Assignee == assignee)
                {
                    Array.Resize(ref filteredArray, filteredArray.Length + 1);
                    filteredArray[filteredArray.Length - 1] = todoItem;
                }
            }
            return filteredArray;
        }

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] filteredArray = new Todo[0];
            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Assignee == null)
                {
                    Array.Resize(ref filteredArray, filteredArray.Length + 1);
                    filteredArray[filteredArray.Length - 1] = todoItem;
                }
            }
            return filteredArray;
        }

        public void RemoveTodo(int id)
        {
       
            for (int i = 0; i < todoArray.Length; i++)
            {
                if (todoArray[i].TodoId == id)
                {
                   
                    for (int offset = i+1; offset < todoArray.Length; offset++, i++)
                    {
                          todoArray[i] = todoArray[offset];
                    }
                    Array.Resize(ref todoArray, todoArray.Length - 1);
                    break;                    
                }
           }
           
        }

    }//class
}//namespace

