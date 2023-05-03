using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class ResourceRepo
    {
        private List<Resource> resources;

        public int Count
        {
            get { return resources.Count; }
        }

        public ResourceRepo()
        {
            resources = new List<Resource>();
        }

        public void AddResource(Resource resource)
        {
            resources.Add(resource);
        }

        public Resource GetResourceAtIndex(int index)
        {
            Resource resourceResult = null;
            if (index >= 0 && index < resources.Count)
            {
                resourceResult = resources[index];
            }

            return resourceResult;
        }

        public void RemoveResource(Resource resource)
        {
            if (resource != null)
            {
                resources.Remove(resource);
            }
        }
    }
}
