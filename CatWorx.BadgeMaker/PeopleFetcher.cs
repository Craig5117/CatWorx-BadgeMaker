using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

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
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                foreach (JToken token in json.SelectToken("results"))
                {
                    string firstName = token.SelectToken("name.first").ToString();
                    string lastName = token.SelectToken("name.last").ToString();
                    string photoUrl = token.SelectToken("picture.large").ToString();
                    int id = Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", ""));
                    Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                    employees.Add(currentEmployee);
                }
            }
                return employees;
        }
    }
}