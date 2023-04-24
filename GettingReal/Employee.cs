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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Employee(int id, string name, string role)  
        {  
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
