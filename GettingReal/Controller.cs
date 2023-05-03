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

        public Employee CurrentInstance { get; private set; }
        public int InstanceCount { get; private set; }
        public int InstanceIndex { get; private set; }

        public Controller()
        {
            CurrentEmployee = null;
            CurrentResource = null;
            CurrentProject = null;

            employeeRepo = new EmployeeRepo();
            resourceRepo = new ResourceRepo();
            projectRepo = new ProjectRepo();

            EmployeeCount = 0;
            EmployeeIndex = -1;
            ResourceCount = 0;
            ResourceIndex = -1;
            ProjectCount = 0; 
            ProjectIndex = -1;

            //For GUI
            CurrentInstance = null;
            InstanceCount = 0;
            InstanceIndex = -1;
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            CurrentEmployee = employee;
            employeeRepo.AddEmployee(employee);
            EmployeeCount = employeeRepo.Count;
            EmployeeIndex = EmployeeCount - 1;

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
