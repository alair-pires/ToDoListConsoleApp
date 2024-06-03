using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ToDoListConsoleApp;
using Xunit;

namespace ToDoListConsoleAppTest
{
    public class ToDoListTest
    {
        private ToDoList toDoList = new ToDoList();

        [Fact]
        public void AddTask_ShouldAddNewTask()
        {
            // Act
            toDoList.AddTask("Nova Tarefa");

            // Assert
            Assert.Contains(toDoList.taskList, task => task.TaskName == "Nova Tarefa");
        }

        [Fact]
        public void ConvertToInt_ShouldConvertValidInput()
        {
            // Arrange
            var input = "5";

            // Act
            var result = toDoList.ConvertToInt(input);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void ConvertToInt_ShouldPromptForValidInput()
        {
            // Arrange
            var input = "abc";

            // Simulate user input sequence for retry
            Console.SetIn(new System.IO.StringReader("abc\n123"));

            // Act
            var result = toDoList.ConvertToInt(input);

            // Assert
            Assert.Equal(123, result);
        }

        [Fact]
        public void AlterStatus_ShouldToggleTaskStatus()
        {
            // Arrange
            var taskIndex = 1; // Considering 1-based index from user input

            // Act
            toDoList.AlterStatus(taskIndex);

            // Assert
            Assert.False(toDoList.taskList[taskIndex].Status);
        }

        [Fact]
        public void ValidateName_ShouldReturnTrimmedName()
        {
            // Arrange
            var input = "  Tarefa com espaços  ";

            // Act
            var result = toDoList.ValidateName(input);

            // Assert
            Assert.Equal("Tarefa com espaços", result);
        }

        [Fact]
        public void ValidateName_ShouldPromptForValidName()
        {
            // Arrange
            var input = "   ";

            Console.SetIn(new System.IO.StringReader("   \nNome Valido"));

            // Act
            var result = toDoList.ValidateName(input);

            // Assert
            Assert.Equal("Nome Valido", result);
        }

        [Fact]
        public void FindTaskById_ShouldReturnTask()
        {
            // Arrange
            var taskId = 1; // Assuming TaskId starts from 1

            // Act
            var result = toDoList.FindTaskById(taskId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(taskId, result.TaskId);
        }

        [Fact]
        public void DeleteTask_ShouldRemoveTask()
        {
            // Arrange
            var taskId = 1;

            // Act
            toDoList.DeleteTask(taskId);

            // Assert
            Assert.DoesNotContain(toDoList.taskList, task => task.TaskId == taskId);
        }
    }
}
