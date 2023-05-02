using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class EmployeeRepo
    {
        private List<Employee> employees;

        public int Count
        {
            get { return employees.Count; }
        }

        public EmployeeRepo()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee GetEmployeeAtIndex(int index)
        {
            Employee employeeResultat = null;
            if (index >= 0 && index < employees.Count)
            {
                employeeResultat = employees[index];
            }

            return employeeResultat;
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}
