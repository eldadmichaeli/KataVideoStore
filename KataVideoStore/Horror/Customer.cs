using System.Text;

namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private string Name { get; }
        private readonly Dictionary<Movie, int> _rentals;

        public Customer(string name)
        {
            Name = name;
            _rentals = new Dictionary<Movie, int>();
        }

        public void AddRental(Movie movie, int daysRented)
        {
            _rentals.Add(movie, daysRented);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            StringBuilder result = new StringBuilder();
            result.Append($"Rental Record for { Name }\n");
            foreach (var rental in _rentals)
            {
                double thisAmount = 0;
                switch (rental.Key.PriceCode)
                {
                    case Movie.Regular:
                        thisAmount += rental.Value > 2 ? 2 + (rental.Value - 2) * 1.5 : 2;
                        break;
                    case Movie.NewRelease:
                        thisAmount += rental.Value * 3;
                        break;
                    case Movie.Children:
                        thisAmount += rental.Value > 3 ? 1.5 + (rental.Value - 3) * 1.5 : 1.5;
                        break;
                }
                frequentRenterPoints++;
                if (rental.Key.PriceCode == Movie.NewRelease && rental.Value > 1)
                    frequentRenterPoints++;
                result.Append($"\t{rental.Key.Title}\t{thisAmount}\n");
                totalAmount += thisAmount;
            }
            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");
            return result.ToString();
        }
    }
}