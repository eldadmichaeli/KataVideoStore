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
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + GetName() + "\n";
            foreach (var rental in rentalsDaysPerMovie)
            {
                double thisAmount = 0;
                switch (rental.Key.GetPriceCode())
                {
                    case MovieType.REGULAR:
                        thisAmount += 2;
                        if (rental.Value > 2)
                            thisAmount += (rental.Value - 2) * 1.5;
                        break;
                    case MovieType.NEW_RELEASE:
                        thisAmount += rental.Value * 3;
                        break;
                    case MovieType.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.Value > 3)
                            thisAmount += (rental.Value - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if ((rental.Key.GetPriceCode() == MovieType.NEW_RELEASE) && rental.Value > 1)
                    frequentRenterPoints++;
                result += "\t" + rental.Key.GetTitle() + "\t" + thisAmount.ToString(CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}