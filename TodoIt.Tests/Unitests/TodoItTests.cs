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
            Person testPerson = new Person(4, "Tom", "Lind");

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
            Person testPerson = new Person(2, "Sam", "Jonsson");

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
            Person testPerson = new Person(personId, firstName, lastName);

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
            Assert.Equal(todoId, testTodo.TodoId );
            Assert.Equal(description, testTodo.Description);
            

        }

        //------------PersonSequencer Tests ----------------------------

        [Fact]
        public void IncrementPersonIdTest()
        {

            //Arrange            
           PersonSequencer testSequencer = new PersonSequencer(5);

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
            TodoSequencer testSequencer = new TodoSequencer(5);

            //Act
            int result = PersonSequencer.NextPersonId();
            int expected = 6;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ResetTodoIdTest()
        {
            //Arrange
            int expected = 0;
            int actual;
            actual = TodoSequencer.TodoId;

            //Act
            TodoSequencer.TodoId = 5;
            TodoSequencer.Reset();


            //Assert
            Assert.Equal(expected, actual);


        }

    }
}

