﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class EmployeeClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }


        //Virker ikke hvis constructoren er en del af koden
        /*public EmployeeClass(int id, string firstname, string lastname, string role)  
        {  
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
        }*/
    }
}
