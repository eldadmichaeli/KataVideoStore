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
            var result = new StringBuilder();

            result.Append($"Rental Record for {Name}\n");

            foreach (var rental in _rentals)
            {
                var thisAmount = CalculateAmount(rental.Key.PriceCode, rental.Value);

                frequentRenterPoints++;

                if (rental.Key.PriceCode == PriceCodeType.NewRelease && rental.Value > 1)
                    frequentRenterPoints++;

                result.Append($"\t{rental.Key.Title}\t{thisAmount}\n");
                totalAmount += thisAmount;
            }

            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");

            return result.ToString();
        }

        private static double CalculateAmount(PriceCodeType priceCode, int rentalValue)
        {
            double amount = 0;

            switch (priceCode)
            {
                case PriceCodeType.Regular:
                    amount += rentalValue > 2 ? 2 + (rentalValue - 2) * 1.5 : 2;
                    break;
                case PriceCodeType.NewRelease:
                    amount += rentalValue * 3;
                    break;
                case PriceCodeType.Children:
                    amount += rentalValue > 3 ? 1.5 + (rentalValue - 3) * 1.5 : 1.5;
                    break;
            }

            return amount;
        }
    }
}