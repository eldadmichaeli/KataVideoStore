namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        public string CustomerName { get; }
        private readonly Dictionary<Movie, int> rentals = new Dictionary<Movie, int>();

        public Customer(string customerName)
        {
            CustomerName = customerName;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            rentals.Add(movie, daysRented);
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + CustomerName + "\n";
            foreach (var rental in rentals)
            {
                var movie = rental.Key;
                var daysRented = rental.Value;
                double thisAmount = 0;

                switch (movie.PriceCode)
                {
                    case (int)MovieType.REGULAR:
                        thisAmount += 2;
                        if (daysRented > 2)
                            thisAmount += (daysRented - 2) * 1.5;
                        break;
                    case (int)MovieType.NEW_RELEASE:
                        thisAmount += daysRented * 3;
                        break;
                    case (int)MovieType.CHILDREN:
                        thisAmount += 1.5;
                        if (daysRented > 3)
                            thisAmount += (daysRented - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if (movie.PriceCode == (int)MovieType.NEW_RELEASE && daysRented > 1)
                    frequentRenterPoints++;
                result += "\t" + movie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}