namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();
        
        private const double BASE_REGULAR_PRICE = 2.0;
        private const double BASE_NEWRELEASE_PRICE = 0;
        private const double BASE_CHILDREN_PRICE = 1.5;

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
                switch (rental.Movie.PriceCode)
                {
                    case PriceCode.Regular:
                        thisAmount = CalculateRegular(rental, thisAmount);
                        break;
                    case PriceCode.NewRelease:
                        thisAmount += rental.Days * 3;
                        break;
                    case PriceCode.Children:
                        thisAmount += BASE_CHILDREN_PRICE;
                        if (rental.Days > 3)
                            thisAmount += (rental.Days - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if ((rental.Movie.PriceCode == PriceCode.NewRelease) && rental.Days > 1)
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
            thisAmount += BASE_REGULAR_PRICE;
            if (rental.Days > 2)
                thisAmount += (rental.Days - 2) * 1.5;

            return thisAmount;
        }
    }
}