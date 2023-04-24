using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(string role, string name, int id)  
        {  
            Role = role;
            Name = name;
            Id = id;
        }
    }
}
