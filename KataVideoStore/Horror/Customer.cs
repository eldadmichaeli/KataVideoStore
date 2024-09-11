namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            _rentals.Add(new Rental(movie, daysRented));
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + _name + "\n";
            foreach (var rental in _rentals)
            {
                double thisAmount = 0;
                switch (rental.Movie.GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount = CalculateRegular(rental, thisAmount);
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.Days * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.Days > 3)
                            thisAmount += (rental.Days - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if ((rental.Movie.GetPriceCode() == Movie.NEW_RELEASE) && rental.Days > 1)
                    frequentRenterPoints++;
                result += "\t" + rental.Movie.GetTitle() + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double CalculateRegular(Rental rental, double thisAmount)
        {
            thisAmount += 2;
            if (rental.Days > 2)
                thisAmount += (rental.Days - 2) * 1.5;

            return thisAmount;
        }
    }
}