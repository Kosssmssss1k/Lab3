using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    // Клас для представлення члена команди
    public class TeamMember
    {
        public string Name { get; }  // Ім'я члена команди
        public int Id { get; }       // Унікальний ідентифікатор члена команди

        // Конструктор для ініціалізації члена команди
        public TeamMember(string name, int id)
        {
            // Перевірка, що ім'я не є порожнім або складається лише з пробілів
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            // Перевірка, що ідентифікатор є додатнім числом
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive value.");
            }

            Name = name;
            Id = id;
        }
    }
}
