using System.Collections.Generic;
using System.Text;

namespace KataVideoStore.Horror
{
    public class RentalOrder
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (var rental in _rentals)
            {
                total += rental.GetCharge();
            }

            return total;
        }

        public int CalculateFrequentRentalPoints()
        {
            int total = 0;
            foreach (var rental in _rentals)
            {
                total += rental.GetFrequentRenterPoints();
            }

            return total;
        }

        public string PrintRentals()
        {
            StringBuilder result = new StringBuilder();

            foreach (var rental in _rentals)
            {
                result.Append($"\t{rental.Movie.Title}\t{rental.GetCharge()}\n");
            }

            return result.ToString();
        }
    }
}