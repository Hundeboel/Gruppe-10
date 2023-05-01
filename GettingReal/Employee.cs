using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }


        public Employee(int id, string firstname, string lastname, string role, bool status, DateTime date)  
        {  
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            Status = status;
            Date = date;
        }
    }
}
