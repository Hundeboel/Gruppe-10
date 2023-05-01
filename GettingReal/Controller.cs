using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class Controller
    {
        //Falsk kode til at koble GUI op
        //Bruger employeeRepo (+ employee) 
        private EmployeeRepo employeeRepo;
        public Employee CurrentInstance { get; private set; }
        public int InstanceCount { get; private set; }
        public int InstanceIndex { get; private set; }

        private ProjectRepo projectRepo;
        public Project CurrentProject { get; private set; }
        public int ProjectCount { get; private set; }
        public int ProjectIndex { get; private set; }


        public Controller()
        {
            CurrentInstance = null;
            employeeRepo= new EmployeeRepo();
            InstanceCount = 0;
            InstanceIndex = -1;
        }

        public void AddInstance()
        {
            Employee employee = new Employee();
            CurrentInstance = employee;
            employeeRepo.AddEmployee(employee);
            InstanceCount = employeeRepo.Count;
            InstanceIndex = InstanceCount - 1;

        }

        public void RemoveInstance()
        {
            if (CurrentInstance != null)
            {
                employeeRepo.RemoveEmployee(CurrentInstance);

                InstanceCount = employeeRepo.Count;
                if(InstanceIndex == InstanceCount)
                {
                    InstanceIndex--;
                }

                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }

        public void NextInstance()
        {
            if(InstanceIndex < InstanceCount - 1)
            {
                InstanceIndex++;
                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }

        public void PrevInstance()
        {
            if(InstanceIndex > 0) 
            { 
                InstanceIndex--;
                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }
    }
}
