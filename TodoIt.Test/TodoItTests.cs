using System;
using Xunit;
using TodoIt.Models;
using TodoIt.Data;



namespace TodoIt.Tests
{
    public class TodoItTests
    {

        // ----------  Person Tests ------------------

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FirstNameBadValueTest(string badFirstName)
        {
            //Arrange
            Person testPerson = new Person("Jonna", "Lind", PersonSequencer.NextPersonId());

            //Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => testPerson.FirstName = badFirstName);

            //Assert
            Assert.Contains("Firstname", exception.Message);

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void LastNameBadValueTest(string badLastName)
        {
            //Arrange
            Person testPerson = new Person("Sam", "Jonsson", PersonSequencer.NextPersonId());

            //Act
            var exception = Assert.Throws<ArgumentException>(() => testPerson.LastName = badLastName);

            //Assert
            Assert.Contains("Lastname", exception.Message);
        }




        [Fact]
        public void PersonClassTest()
        {
            // Arrange
            string firstName1 = "Susy";
            string lastName1 = "Lund";
            string firstName2 = "Melwin";
            string lastName2 = "Carlsson";


            // Act
            Person testPerson1 = new Person(firstName1, lastName1, PersonSequencer.NextPersonId());
            Person testPerson2 = new Person(firstName2, lastName2, PersonSequencer.NextPersonId());

            // Assert        
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);
            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);


        }

        //----------------Todo Tests -----------------------

        [Fact]
        public void TodoClassTest()
        {
            //Arrange
            string description1 = "Finish assignment";
            string description2 = "Go for walk";

            //Act
            Todo testTodo1 = new Todo(description1, TodoSequencer.NextTodoId());
            Todo testTodo2 = new Todo(description2, TodoSequencer.NextTodoId());

            //Assert

            Assert.Equal(description1, testTodo1.Description);
            Assert.Equal(description2, testTodo2.Description);


        }

        //------------PersonSequencer Tests ----------------------------
        [Fact]
        public void ResetPersonIdTest()
        {

            //Arrange
            PersonSequencer.Reset();
            int expected = 0;
            int actual;
            actual = PersonSequencer.PersonId;

            //Act
            PersonSequencer.PersonId = 5;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NextPersonIdTest()
        {
            //Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;
            int id1;
            int id2;

            //Act
            id1 = PersonSequencer.NextPersonId();
            id2 = PersonSequencer.NextPersonId();


            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);

        }

        

        //-------Todo Sequencer Test --------------------------------------


        [Fact]
        public void ResetTodoIdTest()
        {
            //Arrange
            int expected = 0;
            TodoSequencer.TodoId = 4;

            //Act
            TodoSequencer.Reset();


            //Assert
            Assert.Equal(expected, TodoSequencer.TodoId);

        }

        [Fact]

        public void NextTodoIdTest()
        {

            //Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;
            int id1;
            int id2;

            //Act
            id1 = TodoSequencer.NextTodoId();
            id2 = TodoSequencer.NextTodoId();


            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);
        }



        // ----------People Tests --------------------

        [Fact]

        public void CreateNewPersonTest()
        {
            People testingPeople = new People();
            testingPeople.Clear();
            string firstName1 = "Hanna";
            string lastName1 = "Ljung";
            string firstName2 = "Mona";
            string lastName2 = "Lund";


            //Act
            Person testPerson1 = testingPeople.CreateNewPerson(firstName1, lastName1);
            Person testPerson2 = testingPeople.CreateNewPerson(firstName2, lastName2);

            //Assert
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);

            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);

        }


        [Fact]
        public void FindPersonByIdTest()
        {
            //Arrange
            People testingPeople = new People();
            Person testPerson1 = testingPeople.CreateNewPerson("Fred", "Lindberg");
            Person testPerson2 = testingPeople.CreateNewPerson("Anna", "Molin");
            Person testPerson3 = testingPeople.CreateNewPerson("Jens", "Schmidth");
            int checkedPersonId = testPerson2.PersonId;
           
            //Act
            Person matchedPerson = testingPeople.FindById(checkedPersonId);

            //Assert
            Assert.NotEqual(matchedPerson, testPerson1);
            Assert.Equal(matchedPerson, testPerson2);
            Assert.NotEqual(matchedPerson, testPerson3);
        }
        [Fact]
        public void SizePersonTest()
        {
            //Assert
            People testingPeople = new People();
            testingPeople.CreateNewPerson("Hanna", "Ljung");
            testingPeople.CreateNewPerson("Mona", "Lund");

            int expectedSize = 2;

            //Act
            int actualSize = testingPeople.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }

        [Fact]
        public void FindAllPeopleTest()
        {
            //Arrange            
            People testingPeople = new People();
            testingPeople.Clear();

            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }

        [Fact]
        public void RemovePersonTest()
        {
            //Arrange
            People testPerson = new People();

            Person testPerson1 = testPerson.CreateNewPerson("Maja", "Ljung");
            Person testPerson2 = testPerson.CreateNewPerson("Ludwig", "Hallberg");
            Person testPerson3 = testPerson.CreateNewPerson("Anna", "Larsson");
            

            //Act
            testPerson.RemovePerson(testPerson2.PersonId);

            //Assert
            Assert.Contains(testPerson1, testPerson.FindAll());
            Assert.DoesNotContain(testPerson2, testPerson.FindAll());
            Assert.Contains(testPerson3, testPerson.FindAll());
        }

        // ----------TodoItem Tests --------------------

        [Fact]

        public void CreateNewTodoTest()
        {
            //Arrange
            TodoItem testingTodo = new TodoItem();
            testingTodo.Clear();
           
            string description1 = "Study";            
            string description2 = "Exercise";            
            string description3 = "Cook";          
           

            //Act
            Todo testPerson1 = testingTodo.CreateNewTodo(description1);
            Todo testPerson2 = testingTodo.CreateNewTodo(description2);
            Todo testPerson3 = testingTodo.CreateNewTodo(description3);

            //Assert
            Assert.Equal(description1, testPerson1.Description);
            Assert.Equal(description2, testPerson2.Description);
            Assert.Equal(description3, testPerson3.Description);
        }

        [Fact]
        
        public void FindTodoByIdTest()
        {
            //Arrange
            TodoItem testingTodos = new TodoItem();

            Todo testTodo1 = testingTodos.CreateNewTodo("Read");
            Todo testTodo2 = testingTodos.CreateNewTodo("Go swimming");
            Todo testTodo3 = testingTodos.CreateNewTodo("Finish assignment");
            int checkedTodoId = testTodo3.TodoId;

            //Act
           Todo matchedTodo = testingTodos.FindById(checkedTodoId);

            //Assert
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.Equal(matchedTodo, testTodo3);
           
        }


        [Fact]
        public void TodoSizeTest()
        {
            //Assert

            People testingPeople = new People();
            testingPeople.CreateNewPerson("Hanna", "Ljung");
            testingPeople.CreateNewPerson("Mona", "Lund");

            int expectedSize = 2;

            //Act
            int actualSize = testingPeople.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }

        [Fact]
        public void FindAllTodosTest()
        {
            //Arrange            
            People testingPeople = new People();
            testingPeople.Clear();

            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }

        [Fact]
        public void FindByDoneTest()
        {
            //Arrange
            TodoItem todoTest = new TodoItem();
            todoTest.Clear();

            Todo todo1 = todoTest.CreateNewTodo("Go running");
            Todo todo2 = todoTest.CreateNewTodo("Relax");
            Todo todo3 = todoTest.CreateNewTodo("Finish Assignment");

            todoTest.FindById(todo1.TodoId).Done = true;
            todoTest.FindById(todo2.TodoId).Done = false;
            todoTest.FindById(todo3.TodoId).Done = true;

            //Act
            Todo[] findDones = todoTest.FindByDoneStatus(true);

            //Assert
            for (int i = 0; i < findDones.Length; i++)
            {
                Assert.True(findDones[i].Done);
            }

            Assert.Contains(todo1, findDones);
            Assert.Contains(todo3, findDones);

        }

        [Fact]
        public void TestFindByAssigneeId()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();

            Person assignee = new Person("Fred", "Johnsson", personId);

            TodoItem testTodos = new TodoItem();
            testTodos.Clear();

            Todo todo1 = testTodos.CreateNewTodo("Go for a run");
            Todo todo2 = testTodos.CreateNewTodo("Sleep");
            Todo todo3 = testTodos.CreateNewTodo("Finish the test");
            Todo todo4 = testTodos.CreateNewTodo("Watch TV");

            todo1.Assignee = assignee;
            todo2.Assignee = assignee;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(personId);

            //Assert
            Assert.Contains(todo1, findAssigneeArray);
            Assert.Contains(todo2, findAssigneeArray);
            Assert.DoesNotContain(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo4, findAssigneeArray);

        }
        [Fact]
        public void FindByAssigneePersonTest()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            string firstName1 = "Fred";
            string lastName1 = "Johnsson";
            string firstName2 = "Edwin";
            string lastName2 = "Nylén";

            Person assignee1 = new Person(firstName1, lastName1, personId);
            Person expectedAssignee = new Person(firstName2, lastName2, personId);

            TodoItem testTodos = new TodoItem();
            testTodos.Clear();


            Todo todo1 = testTodos.CreateNewTodo("Go for a run");
            Todo todo2 = testTodos.CreateNewTodo("Sleep");
            Todo todo3 = testTodos.CreateNewTodo("Finish the test");

            todo1.Assignee = assignee1;
            todo2.Assignee = expectedAssignee;
            todo3.Assignee = expectedAssignee;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(expectedAssignee);

            //Assert
            Assert.Contains(todo2, findAssigneeArray);
            Assert.Contains(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo1, findAssigneeArray);
        }

        [Fact]
        public void FindUnassignedTodoTest()
        {
            //Arrange
            Person testPerson = new Person("Lotta", "Svensson", PersonSequencer.NextPersonId());
            TodoItem testTodos = new TodoItem();
            Todo todo1 = testTodos.CreateNewTodo("Have a rest");
            Todo todo2 = testTodos.CreateNewTodo("Eat");
            Todo todo3 = testTodos.CreateNewTodo("Work");
            Todo todo4 = testTodos.CreateNewTodo("Study");
            todo1.Assignee = testPerson;
            todo3.Assignee = testPerson;

            //Act
            Todo[] unassignedTodos = testTodos.FindUnassignedTodoItems();

            //Assert
            Assert.Contains(todo2, unassignedTodos);
            Assert.Contains(todo4, unassignedTodos);
            Assert.DoesNotContain(todo1, unassignedTodos);
            Assert.DoesNotContain(todo3, unassignedTodos);
        }

        [Fact]
        public void RemoveTodoTest()
        {
            //Arrange
            TodoItem testTodo = new TodoItem();

            Todo todo1 = testTodo.CreateNewTodo("Eat");
            Todo todo2 = testTodo.CreateNewTodo("Sleap");
            Todo todo3 = testTodo.CreateNewTodo("Run");

            //Act
            testTodo.RemoveTodo(todo1.TodoId);

            //Assert
            Assert.Contains(todo2, testTodo.FindAll());
            Assert.Contains(todo3, testTodo.FindAll());
            Assert.DoesNotContain(todo1, testTodo.FindAll());
        }

    }//class
}//namespace


