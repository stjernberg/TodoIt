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
            Assert.Contains("FirstName", exception.Message);

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
            Assert.Contains("LastName", exception.Message);
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
        public void IncrementPersonIdTest()
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

        [Fact]
        public void ResetPersonIdTest()
        {

            
           //Arrange
            int expected = 0;
            int actual;
            actual = PersonSequencer.PersonId;

            //Act
            PersonSequencer.PersonId = 5;
            PersonSequencer.Reset();


            //Assert
            Assert.Equal(expected, actual);
        }

        //-------Todo Sequencer Test --------------------------------------

        [Fact]
        public void IncrementTodoIdTest()
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


        // ----------People Tests --------------------
        
        [Fact]

        public void CreateNewPersonTest()
        {
            string firstName1 = "Hanna";
           string lastName1 = "Ljung";
           int expectedId1 = 1;
           string firstName2 = "Mona";
           string lastName2 = "Lund";
           int expectedId2 = 2;
           People testingPeople = new People();
           testingPeople.Clear();


           //Act
           Person testPerson1 = testingPeople.CreateNewPerson(firstName1, lastName1);
           Person testPerson2 = testingPeople.CreateNewPerson(firstName2, lastName2);

           //Assert
           Assert.Equal(firstName1, testPerson1.FirstName);
           Assert.Equal(lastName1, testPerson1.LastName);
           Assert.Equal(expectedId1, testPerson1.PersonId);
           Assert.Equal(firstName2, testPerson2.FirstName);
           Assert.Equal(lastName2, testPerson2.LastName);
           Assert.Equal(expectedId2, testPerson2.PersonId);
        }

        
        [Fact]
        public void FindPersonByIdTest()
        {
            //Arrange

            People testingPeople = new People();

            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");

            int checkedPersonId = 2;
            Person matchedPerson;

            //Act
            matchedPerson = testingPeople.FindById(checkedPersonId);

            //Assert
            Assert.Equal(checkedPersonId, matchedPerson.PersonId);
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

        // ----------TodoItem Tests --------------------
        
        [Fact]

        public void CreateNewTodoTest()
        {
            
            //Arrange

            string description1 = "Study";
            int expectedId1 = 1;
            string description2 = "Exercise";
            int expectedId2 = 2;
            string description3 = "Cook";
            int expectedId3 = 3;
            TodoItem testingTodo = new TodoItem();
            testingTodo.Clear();

            //Act
            Todo testPerson1 = testingTodo.CreateNewTodo(description1);
            Todo testPerson2 = testingTodo.CreateNewTodo(description2);
            Todo testPerson3 = testingTodo.CreateNewTodo(description3);

            //Assert
            Assert.Equal(description1, testPerson1.Description);
            Assert.Equal(expectedId1, testPerson1.TodoId);
            Assert.Equal(description2, testPerson2.Description);
            Assert.Equal(expectedId2, testPerson2.TodoId);
            Assert.Equal(description3, testPerson3.Description);
            Assert.Equal(expectedId3, testPerson3.TodoId);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindTodoByIdTest(int checkedTodoId)
        {
            //Arrange

            TodoItem testingPeople = new TodoItem();

            testingPeople.CreateNewTodo("Read");
            testingPeople.CreateNewTodo("Go swimming");
            testingPeople.CreateNewTodo("Finish assignment");

            Todo matchedPerson;

            //Act
            matchedPerson = testingPeople.FindById(checkedTodoId);

            //Assert
            Assert.Equal(checkedTodoId, matchedPerson.TodoId);

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
            //Create an assignee
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
            string firstName1 = "Fred";
            string lastName1 = "Johnsson";
            string firstName2 = "Edwin";
            string lastName2 = "Nylén";

            Person assignee1 = new Person(firstName1, lastName1, personId);
            Person assignee2 = new Person(firstName2, lastName2, personId);

            TodoItem testTodos = new TodoItem();
            testTodos.Clear();

                       Todo todo1 = testTodos.CreateNewTodo("Go for a run");
            Todo todo2 = testTodos.CreateNewTodo("Sleep");
            Todo todo3 = testTodos.CreateNewTodo("Finish the test");

            todo1.Assignee = assignee1;
            todo2.Assignee = assignee2;
            todo3.Assignee = assignee2;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(personId);

            //Assert
            Assert.Equal(assignee1.PersonId, findAssigneeArray[0].Assignee.PersonId);
            Assert.Equal(assignee2.PersonId, findAssigneeArray[1].Assignee.PersonId);
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
            Assert.Equal(expectedAssignee, findAssigneeArray[0].Assignee);
            Assert.Equal(expectedAssignee, findAssigneeArray[1].Assignee);
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
            Assert.Equal(todo2.TodoId, unassignedTodos[0].TodoId);
            Assert.Equal(todo4.TodoId, unassignedTodos[1].TodoId);

        }




    }//class
}//namespace


