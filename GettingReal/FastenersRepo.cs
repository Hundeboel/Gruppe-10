using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    public class FastenersRepo
    {
        private List<Fastener> fasteners;

        public int Count
        {
            get { return fasteners.Count; }
        }

        public FastenersRepo()
        {
            fasteners = new List<Fastener>();
        }

        public void AddFastener(Fastener fastener)
        {
            fasteners.Add(fastener);
        }

        public Fastener GetFastenerAtIndex(int index)
        {
            Fastener fastenerResultat  = null;
            if (index >= 0 && index < fasteners.Count)
            {
                fastenerResultat = fasteners[index];
            }

            return fastenerResultat;
        }

        public void RemoveFastener(Fastener fastener)
        {
            if (fastener != null)
            {
                fasteners.Remove(fastener);
            }
        }
    }
}
