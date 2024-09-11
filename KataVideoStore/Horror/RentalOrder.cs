using System.Collections.Generic;
using System.Linq;
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

        public double CalculateTotalPrice() =>
            _rentals.Sum(rental => rental.GetCharge());

        public int CalculateFrequentRentalPoints() =>
            _rentals.Sum(rental => rental.GetFrequentRenterPoints());

        public string PrintRentals()
        {
            return _rentals
                .Select(rental => $"\t{rental.Movie.Title}\t{rental.GetCharge()}\n")
                .Aggregate(new StringBuilder(), (sb, s) => sb.Append(s))
                .ToString();
        }
    }
}