using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class ProjectRepo
    {
        private List<Project> projects;


        public int Count
        {
            get { return projects.Count; }
        }

        public ProjectRepo()
        {
            projects = new List<Project>();
        }


        public void AddProject(Project project)
        {
            projects.Add(project);
        }


        /* public Project GetProjectByName(int index) 
         { 
             Project projectResult = null;
             if (index >= 0 && index < projects.Count) 
             { 
                 projectResult = projects[index];
             }

             return projectResult;
         }
        */

        public Project GetProjectAtIndex(int index)
        {
            Project projectResult = null;
            if (index >= 0 && index < projects.Count)
            {
                projectResult = projects[index];
            }

            return projectResult;
        }

        public void RemoveProject(Project project)
        {
            if (project != null)
            {
                projects.Remove(project);
            }
        }



    }
}