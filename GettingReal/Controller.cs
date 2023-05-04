using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFapp
{
    public class Controller
    {
        //Falsk kode til at koble GUI op
        //Bruger employeeRepo (+ employee) 
        private EmployeeRepo employeeRepo;
        public Employee CurrentEmployee { get; private set; }
        public int EmployeeCount { get; private set; }
        public int EmployeeIndex { get; private set; }

        private ResourceRepo resourceRepo;
        public Resource CurrentResource { get; private set; }
        public int ResourceCount { get; private set; }
        public int ResourceIndex { get; private set; }

        private ProjectRepo projectRepo;
        public Project CurrentProject { get; private set; }
        public int ProjectCount { get; private set; }
        public int ProjectIndex { get; private set; }

        private FastenersRepo fastenerRepo;
        public Fastener CurrentFastener { get; private set; }
        public int FastenerCount { get; private set; }
        public int FastenerIndex { get; private set; }

        private RentalRepo rentalRepo;
        public Rental CurrentRental { get; private set; }
        public int RentalCount { get; private set; }
        public int RentalIndex { get; private set; }


        public Employee CurrentInstance { get; private set; }
        public int InstanceCount { get; private set; }
        public int InstanceIndex { get; private set; }
        public Controller()
        {
            CurrentEmployee = null;
            CurrentResource = null;
            CurrentProject = null;
            CurrentFastener = null;
            CurrentRental = null;

            employeeRepo = new EmployeeRepo();
            resourceRepo = new ResourceRepo();
            projectRepo = new ProjectRepo();
            fastenerRepo = new FastenersRepo();
            rentalRepo = new RentalRepo();

            EmployeeCount = 0;
            EmployeeIndex = -1;
            ResourceCount = 0;
            ResourceIndex = -1;
            ProjectCount = 0; 
            ProjectIndex = -1;
            FastenerCount = 0;
            FastenerIndex = -1;
            RentalCount = 0;
            RentalIndex = -1;

            //For GUI
            CurrentInstance = null;
            InstanceCount = 0;
            InstanceIndex = -1;
        }

        public void SaveEmployee(Employee employee)
        {
            using StreamWriter sw = new StreamWriter(@"..\..\..\..\GettingReal\EmployeeList.txt", true);

            string lineToSave = employee.MakeTitle();
            sw.WriteLine(lineToSave);
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            CurrentEmployee = employee;
            employeeRepo.AddEmployee(employee);
            EmployeeCount = employeeRepo.Count;
            EmployeeIndex = EmployeeCount - 1;
        }

        public void SE()
        { 
            SaveEmployee(CurrentEmployee); 
        }

        public void AddResource()
        {
            Resource resource = new Resource();
            CurrentResource = resource;
            resourceRepo.AddResource(resource);
            ResourceCount = resourceRepo.Count;
            ResourceIndex = ResourceCount - 1;

        }
        public void AddProject() 
        { 
            Project project = new Project();
            CurrentProject = project;
            projectRepo.AddProject(project);
            ProjectCount = projectRepo.Count; 
            ProjectIndex = ProjectCount - 1;
        }
        public void AddFastener()
        {
            Fastener fastener = new Fastener();
            CurrentFastener = fastener;
            fastenerRepo.AddFastener(fastener);
            FastenerCount = fastenerRepo.Count;
            FastenerIndex = FastenerCount - 1;
        }
        public void AddRental()
        {
            Rental rental = new Rental();
            CurrentRental = rental;
            rentalRepo.AddRental(rental);
            RentalCount = rentalRepo.Count;
            RentalIndex = RentalCount - 1;
        }
        public void RemoveEmployee()
        {
            if (CurrentEmployee != null)
            {
                employeeRepo.RemoveEmployee(CurrentEmployee);

                EmployeeCount = employeeRepo.Count;
                if (EmployeeIndex == EmployeeCount)
                {
                    EmployeeIndex--;
                }

                CurrentEmployee = employeeRepo.GetEmployeeAtIndex(EmployeeIndex);
            }
        }
        public void RemoveResource()
        {
            if (CurrentResource != null)
            {
                resourceRepo.RemoveResource(CurrentResource);

                ResourceCount = resourceRepo.Count;
                if (ResourceIndex == ResourceCount)
                {
                    ResourceIndex--;
                }

                CurrentResource = resourceRepo.GetResourceAtIndex(ResourceIndex);
            }
        }

        public void RemoveProject()
        {
            if (CurrentProject != null)
            {
                projectRepo.RemoveProject(CurrentProject);

                ProjectCount = projectRepo.Count;
                if (ProjectIndex == ProjectCount)
                {
                    ProjectIndex--;
                }

                CurrentProject = projectRepo.GetProjectAtIndex(ProjectIndex);
            }
        }

        public void RemoveFastener()
        {
            if (CurrentFastener != null)
            {
                fastenerRepo.RemoveFastener(CurrentFastener);

                FastenerCount = fastenerRepo.Count;
                if (FastenerIndex == FastenerCount)
                {
                    FastenerIndex--;
                }

                CurrentFastener = fastenerRepo.GetFastenerAtIndex(FastenerIndex);
            }
        }

        public void RemoveRental()
        {
            if (CurrentRental != null)
            {
                rentalRepo.RemoveRental(CurrentRental);

                RentalCount = rentalRepo.Count;
                if (RentalIndex == RentalCount)
                {
                    RentalIndex--;
                }

                CurrentRental = rentalRepo.GetRentalAtIndex(RentalIndex);
            }
        }

        public void NextEmployee()
        {
            if (EmployeeIndex < EmployeeCount - 1)
            {
                EmployeeIndex++;
                CurrentEmployee = employeeRepo.GetEmployeeAtIndex(EmployeeIndex);
            }
        }

        public void NextResource()
        {
            if (ResourceIndex < ResourceCount - 1)
            {
                ResourceIndex++;
                CurrentResource = resourceRepo.GetResourceAtIndex(ResourceIndex);
            }
        }

        public void NextProject()
        {
            if (ProjectIndex < ProjectCount - 1)
            {
                ProjectIndex++;
                CurrentProject = projectRepo.GetProjectAtIndex(ProjectIndex);
            }
        }

        public void NextFastener()
        {
            if (FastenerIndex < FastenerCount - 1)
            {
                FastenerIndex++;
                CurrentFastener = fastenerRepo.GetFastenerAtIndex(FastenerIndex);
            }
        }
        public void NextRental()
        {
            if (RentalIndex < RentalCount - 1)
            {
                RentalIndex++;
                CurrentRental = rentalRepo.GetRentalAtIndex(RentalIndex);
            }
        }

        public void PrevEmployee()
        {
            if (EmployeeIndex > 0)
            {
                EmployeeIndex--;
                CurrentEmployee = employeeRepo.GetEmployeeAtIndex(EmployeeIndex);
            }
        }
        public void PrevResource()
        {
            if (ResourceIndex > 0)
            {
                ResourceIndex--;
                CurrentResource = resourceRepo.GetResourceAtIndex(ResourceIndex);
            }
        }

        public void PrevProject()
        { 
            if (ProjectIndex > 0) 
            {
                ProjectIndex--;
                CurrentProject = projectRepo.GetProjectAtIndex(ProjectIndex);
            } 
        }
        public void PrevFastener()
        {
            if (FastenerIndex > 0)
            {
                FastenerIndex--;
                CurrentFastener = fastenerRepo.GetFastenerAtIndex(FastenerIndex);
            }
        }
        public void PrevRental()
        {
            if (RentalIndex > 0)
            {
                RentalIndex--;
                CurrentRental = rentalRepo.GetRentalAtIndex(RentalIndex);
            }
        }

        //For GUI which is not yet added to the controller
        #region 
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
                if (InstanceIndex == InstanceCount)
                {
                    InstanceIndex--;
                }

                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }

        public void NextInstance()
        {
            if (InstanceIndex < InstanceCount - 1)
            {
                InstanceIndex++;
                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }

        public void PrevInstance()
        {
            if (InstanceIndex > 0)
            {
                InstanceIndex--;
                CurrentInstance = employeeRepo.GetEmployeeAtIndex(InstanceIndex);
            }
        }
        #endregion
    }
}
