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
        public void TestFirstNameBadValue(string badFirstName)
        {
            //Arrange
            Person testPerson = new Person("Tom", "Lind", 4);

            //Act
            var exception = Assert.Throws<ArgumentException>(() => testPerson.FirstName = badFirstName);

            //Assert
            Assert.Contains("FirstName", exception.Message);

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void TestLastNameBadValue(string badLastName)
        {
            //Arrange
            Person testPerson = new Person("Sam", "Jonsson", 2);

            //Act
            var exception = Assert.Throws<ArgumentException>(() => testPerson.LastName = badLastName);

            //Assert
            Assert.Contains("LastName", exception.Message);
        }




        [Fact]
        public void CorrectInfoPersonTest()
        {
            //Arrange
            string firstName = "Susy";
            string lastName = "Lund";
            int personId = 1;


            //Act
            Person testPerson = new Person(firstName, lastName, personId);

            //Assert
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
            Assert.Equal(personId, testPerson.PersonId);

        }

        //----------------Todo Tests -----------------------

        [Fact]
        public void CorrectInfoTodoTest()
        {
            //Arrange
            int todoId = 3;
            string description = "Finish assignment";

            //Act
            Todo testTodo = new Todo(todoId, description);

            //Assert
            Assert.Equal(todoId, testTodo.TodoId);
            Assert.Equal(description, testTodo.Description);


        }

        //------------PersonSequencer Tests ----------------------------

        [Fact]
        public void IncrementPersonIdTest()
        {

            //Arrange            
            //PersonSequencer testSequencer = new PersonSequencer(5);

            //Act
            int result = PersonSequencer.NextPersonId();
            int expected = 6;

            //Assert
            Assert.Equal(expected, result);
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
            int startId = 1;          
            int expectedId = 2;
            int id1;
            int id2;

            //Act
            id1 = PersonSequencer.NextPersonId();
            id2 = PersonSequencer.NextPersonId();

            
            //Assert
            Assert.Equal(startId, id1);
            Assert.Equal(expectedId, id2);
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

        public void CheckIfPersonIsCreated()
        {
            //Arrange
           
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

        /*[Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FindPersonByIdTest(int checkedPersonId)
        {
            //Arrange
           
            People testingPeople = new People();
            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");

            Person matchedPerson;

            //Act
            matchedPerson = testingPeople.FindById(checkedPersonId);
           
            //Assert
            Assert.Equal(checkedPersonId, matchedPerson.PersonId);            
        }*/
        [Fact]
        public void FindByIdTest()
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
        public void CheckSizePerson()
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
        public void CheckFindAllPeople()
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

        public void CheckIfTodoIsCreated()
        {
            //Arrange

            string description1 = "Study";
            int expectedId1 = 1;
            string description2 = "Exercise";           
            int expectedId2 = 2;
            string description3 = "Cook";           
            int expectedId3 = 3;
            TodoItem testingPeople = new TodoItem();
            testingPeople.Clear();

            //Act
            Todo testPerson1 = testingPeople.CreateNewTodo(description1);
            Todo testPerson2 = testingPeople.CreateNewTodo(description2);
            Todo testPerson3 = testingPeople.CreateNewTodo(description3);

            //Assert
            Assert.Equal(description1, testPerson1.Description);
            Assert.Equal(expectedId1, testPerson1.TodoId);
            Assert.Equal(description2, testPerson2.Description);
            Assert.Equal(expectedId2, testPerson2.TodoId);
            Assert.Equal(description3, testPerson3.Description);
            Assert.Equal(expectedId3, testPerson3.TodoId);

        }

        [Theory]
        [InlineData (1)]
        [InlineData (2)]
        [InlineData (3)]
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
        public void CheckTodoSize()
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
        public void CheckFindAllTodos()
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

    }//class
}//namespace

