using System.Collections.Generic;
using Xunit;

namespace ConsoleApp1
{
    public class TaskManagementTests
    {
        // Тест для перевірки створення завдання з правильними властивостями
        [Fact]
        public void Task_ShouldBeCreatedWithCorrectProperties()
        {
          
            string expectedTitle = "Task 1";
            string expectedDescription = "Test task description";

            
            var task = new Task(expectedTitle, expectedDescription);

         
            Assert.Equal(expectedTitle, task.Title);  
            Assert.Equal(expectedDescription, task.Description);  
            Assert.Equal("Очікує", task.Status); 
        }

        // Тест для перевірки додавання завдання в TaskManager
        [Fact]
        public void TaskManager_ShouldAddTaskCorrectly()
        {
            
            var taskManager = new TaskManager();
            var task = new Task("Task 1", "Test task description");
            var task2 = new Task("Task 2", "Test task description");

        
            taskManager.AddTask(task);
            taskManager.AddTask(task2);

           
            var allTasks = taskManager.GetAllTasks();  
            Assert.Contains(task2, allTasks);  
        }

        // Тест для перевірки призначення завдання члену команди
        [Fact]
        public void AssignTask_ShouldAssignTaskToMember()
        {
            
            var taskManager = new TaskManager();
            var task = new Task("Task 1", "Test task description");
            var member = new TeamMember("Alice", 1);
            taskManager.AddTask(task);
            var teamMembers = new List<TeamMember> { member };

            
            taskManager.AssignTask(1, 1, teamMembers);  

            
            Assert.Equal(member, task.Assignee);  
        }

        // Тест для перевірки отримання всіх завдань
        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            
            var taskManager = new TaskManager();

            
            var task1 = new Task("Task 1", "Description of Task 1");
            var task2 = new Task("Task 2", "Description of Task 2");
            var task3 = new Task("Task 3", "Description of Task 3");

            
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);

          
            var allTasks = taskManager.GetAllTasks(); 

         
            Assert.Contains(task1, allTasks); 
            Assert.Contains(task2, allTasks); 
            Assert.Contains(task3, allTasks); 
            Assert.Equal(3, allTasks.Count); 
        }

    }
}
