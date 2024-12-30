using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    public class Task
    {
        public string Title { get; }         // Назва завдання
        public string Description { get; }   // Опис завдання
        public string Status { get; private set; } // Статус завдання (наприклад, "Очікує", "Виконується", "Завершено")
        public TeamMember Assignee { get; private set; } // Відповідальний член команди

        // Конструктор для ініціалізації завдання
        public Task(string title, string description)
        {
            // Перевірка, що назва завдання не є порожньою
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            // Перевірка, що опис завдання не є порожнім
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty.");
            }

            Title = title;
            Description = description;
            Status = "Очікує"; // За замовчуванням статус "Очікує"
        }

        // Метод для призначення завдання члену команди
        public void AssignTo(TeamMember member)
        {
            // Перевірка, чи не є переданий член команди пустим
            if (member == null)
            {
                throw new ArgumentException("Assignee must be a valid member.");
            }
            Assignee = member;
        }

        // Метод для зміни статусу завдання
        public void ChangeStatus(string status)
        {
            // Перевірка на допустимі значення статусу
            if (status != "Очікує" && status != "Виконується" && status != "Завершено")
            {
                throw new ArgumentException("Invalid status.");
            }
            Status = status;
        }
    }
}
