using System;
using System.Globalization;

namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private string name;
        private Dictionary<Movie, int> rentalsDaysPerMovie = new Dictionary<Movie, int>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            rentalsDaysPerMovie.Add(movie, daysRented);
        }

        public string GetName()
        {
            return name;
        }

        public string Statement()
        {
            List<(string Movie, double Price)> rentals = new List<(string Movie, double Price)>();

            double totalAmount = 0;
            int frequentRenterPoints = 0;
            
            foreach (var rental in rentalsDaysPerMovie)
            {
                var rentalPrice = GetTotalRentalPricePerMovie(rental.Key, rental.Value);
                
                frequentRenterPoints++;
                if ((rental.Key.PriceCode == PriceCategory.NewRelease) && rental.Value > 1)
                    frequentRenterPoints++;
                rentals.Add((rental.Key.Title, rentalPrice));

                totalAmount += rentalPrice;
            }

            return BuildResult(rentals, totalAmount, frequentRenterPoints);
        }

        public static double GetTotalRentalPricePerMovie(Movie movie, int numberOfDays)
        {
            switch (movie.PriceCode)
            {
                case PriceCategory.Regular:
                    return ApplyPriceWithLateFee(2, 2, numberOfDays);
                case PriceCategory.NewRelease:
                    return numberOfDays * 3;
                case PriceCategory.Childrens:
                    return ApplyPriceWithLateFee(1.5, 3, numberOfDays);
                default:
                    throw new NotImplementedException("Price category not implemented");
            }
        }
        
        public static double ApplyPriceWithLateFee(double price, int allowedDays, int totalDaysRented)
        {
            if (totalDaysRented > allowedDays)
            {
                return (totalDaysRented - allowedDays) * 1.5 + price;    
            }

            return price;
        }

        private string BuildResult(List<(string Movie, double Price)> rentals, double totalAmount, int frequentRenterPoints)
        {
            string result = "Rental Record for " + GetName() + "\n";

            foreach (var rental in rentals)
            {
                result += "\t" + rental.Movie + "\t" + rental.Price.ToString(CultureInfo.InvariantCulture) + "\n";
            }
            
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}