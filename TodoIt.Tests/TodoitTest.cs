using System;
using Xunit;
using TodoIt.Models;

namespace TodoIt.Tests
{
    public class TodoItTest
    {
        [Fact]
        public void TestFirstNameGoodValue()
        {
            //Arrange
            string expectedFirstName = "Luie";
            Person testPerson = new Person(2, "Sam", "Jonsson");

            //Act
            testPerson.FirstName = expectedFirstName;
            string result = testPerson.FirstName;

            //Assert
            Assert.Equal(expectedFirstName, result);
        }

        [Fact]
        public void TestLastNameGoodValue()
        {
            //Arrange
            string expectedLastName = "Sundblad";
            Person testPerson = new Person(4, "Jenny", "Svensson");

            //Act
            testPerson.LastName = expectedLastName;
            string result = testPerson.LastName;

            //Assert
            Assert.Equal(expectedLastName, result);
        }

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
            Person testPerson = new Person(personId, firstName, lastName);

            //Act
            string result = testPerson.InfoPerson();

            //Assert
            Assert.NotNull(result);
            Assert.Contains(firstName, result);
            Assert.Contains(lastName, result);
            Assert.Contains(personId.ToString(), result);

        }

        [Fact]
        public void CorrectInfoTodoTest()
        {
            //Arrange
            int todoId = 3;
            string description = "Finish assignment";
            Todo testTodo = new Todo(todoId, description);

            //Act
            string result = testTodo.InfoTodo();

            //Assert
            Assert.NotNull(result);
            Assert.Contains(todoId.ToString(), result);
            Assert.Contains(description, result);
           
        }


    }
}
