using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Xunit;

namespace ConsoleApp1
{
    public class TaskManagementTests
    {
        // Тест для перевірки створення завдання з правильними властивостями
        [Fact]
        public void Task_ShouldBeCreatedWithCorrectProperties()
        {
            // Arrange
            string expectedTitle = "Task 1";
            string expectedDescription = "Test task description";

            // Act
            var task = new Task(expectedTitle, expectedDescription);

            // Assert
            Assert.Equal(expectedTitle, task.Title);  // Перевіряємо, що назва завдання правильна
            Assert.Equal(expectedDescription, task.Description);  // Перевіряємо, що опис правильний
            Assert.Equal("Очікує", task.Status); // Перевіряємо, що статус за замовчуванням "Очікує"
        }

        // Тест для перевірки додавання завдання в TaskManager
        [Fact]
        public void TaskManager_ShouldAddTaskCorrectly()
        {
            // Arrange
            var taskManager = new TaskManager();
            var task = new Task("Task 1", "Test task description");

            // Act
            taskManager.AddTask(task);  // Додаємо завдання

            // Assert
            var allTasks = taskManager.GetAllTasks();  // Отримуємо список всіх завдань
            Assert.Contains(task, allTasks);  // Перевіряємо, що завдання в списку
        }

        // Тест для перевірки призначення завдання члену команди
        [Fact]
        public void AssignTask_ShouldAssignTaskToMember()
        {
            // Arrange
            var taskManager = new TaskManager();
            var task = new Task("Task 1", "Test task description");
            var member = new TeamMember("Alice", 1);
            taskManager.AddTask(task);
            var teamMembers = new List<TeamMember> { member };

            // Act
            taskManager.AssignTask(1, 1, teamMembers);  // Призначаємо завдання члену команди

            // Assert
            Assert.Equal(member, task.Assignee);  // Перевіряємо, що завдання призначено правильно
        }

        // Тест для перевірки отримання всіх завдань
        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var taskManager = new TaskManager();

            // Створюємо декілька завдань
            var task1 = new Task("Task 1", "Description of Task 1");
            var task2 = new Task("Task 2", "Description of Task 2");
            var task3 = new Task("Task 3", "Description of Task 3");

            // Додаємо їх в менеджер завдань
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);

            // Act
            var allTasks = taskManager.GetAllTasks(); // Отримуємо всі завдання

            // Assert
            Assert.Contains(task1, allTasks); // Перевіряємо, що task1 є в списку
            Assert.Contains(task2, allTasks); // Перевіряємо, що task2 є в списку
            Assert.Contains(task3, allTasks); // Перевіряємо, що task3 є в списку
            Assert.Equal(3, allTasks.Count); // Перевіряємо, що кількість завдань в списку дорівнює 3
        }
    }
}
