using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("Please enter first name (leave empty to exit): ");
                string firstName = Console.ReadLine();
                if (firstName == "")
                {
                    break;
                }
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine();
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }

        public static List<Employee> GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            return employees;
        }
    }
}