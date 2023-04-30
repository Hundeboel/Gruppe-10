using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class EmployeeRepo
    {
        private List<EmployeeClass> employees;

        public int Count
        {
            get { return employees.Count; }
        }

        public EmployeeRepo()
        {
            employees = new List<EmployeeClass>();
        }

        public void AddEmployee(EmployeeClass employee)
        {
            employees.Add(employee);
        }

        public EmployeeClass GetEmployeeAtIndex(int index)
        {
            EmployeeClass employeeResultat = null;
            if (index >= 0 && index < employees.Count)
            {
                employeeResultat = employees[index];
            }

            return employeeResultat;
        }

        public void RemoveEmployeeAtIndex(int index)
        {
            if(index >= 0 && index < employees.Count)
            {
                employees.RemoveAt(index);
            }
        }

        public void RemoveEmployee(EmployeeClass employee)
        {
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}
