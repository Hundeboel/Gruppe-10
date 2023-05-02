using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFapp
{
    class RentalRepo
    {
        private List<Rental> rentals;

        public int Count
        {
            get { return rentals.Count; }
        }

        public RentalRepo()
        {
            rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public Rental GetRentalByResource(int index)
        {
            Rental rentalResult = null;
            if (index >= 0 && index < rentals.Count)
            {
                rentalResult = rentals[index];
            }

            return rentalResult;
        }

        public void RemoveRental(Rental rental)
        {
            if (rental != null)
            {
                rentals.Remove(rental);
            }
        }
    }
}