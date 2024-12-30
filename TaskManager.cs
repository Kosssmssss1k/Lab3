using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();  // Список завдань

        // Метод для додавання нового завдання
        public void AddTask(Task task)
        {
            // Перевірка, що завдання не є null
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");
            }

            tasks.Add(task); // Додаємо завдання в список
        }

        // Метод для призначення завдання члену команди
        public void AssignTask(int taskId, int memberId, List<TeamMember> teamMembers)
        {
            // Знаходимо завдання по його ідентифікатору
            var task = tasks.Find(t => t.Title == "Task " + taskId);
            // Знаходимо члена команди по ідентифікатору
            var member = teamMembers.Find(m => m.Id == memberId);

            // Перевірка, чи знайдено завдання
            if (task == null)
            {
                throw new ArgumentException("Task not found.");
            }

            // Перевірка, чи знайдено члена команди
            if (member == null)
            {
                throw new ArgumentException("Team member not found.");
            }

            task.AssignTo(member); // Призначаємо завдання члену команди
        }

        // Метод для отримання всіх завдань
        public List<Task> GetAllTasks()
        {
            return tasks;  // Повертаємо список всіх завдань
        }
    }
}
