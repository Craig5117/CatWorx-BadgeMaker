using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Console.Clear();
            Console.WriteLine("Press 1 then enter to input employee info manually.");
            Console.WriteLine("Press 2 then enter to retrieve employee info from an API.");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    employees = PeopleFetcher.GetEmployees();
                    break;
                case "2":
                    employees = PeopleFetcher.GetFromAPI();
                    break;
            }            
            Util.MakeCSV(employees);
            Util.MakeBadges(employees);
        }
    }
}
