namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private string name;
        private Dictionary<Movie, int> rentals = new Dictionary<Movie, int>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            rentals.Add(movie, daysRented);
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
            foreach (var rental in rentals)
            {
                double thisAmount = 0;
                switch (rental.Key.PriceCode)
                {
                    case (int)MovieType.REGULAR:
                        thisAmount += 2;
                        if (rental.Value > 2)
                            thisAmount += (rental.Value - 2) * 1.5;
                        break;
                    case (int)MovieType.NEW_RELEASE:
                        thisAmount += rental.Value * 3;
                        break;
                    case (int)MovieType.CHILDREN:
                        thisAmount += 1.5;
                        if (rental.Value > 3)
                            thisAmount += (rental.Value - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if ((rental.Key.PriceCode == (int)MovieType.NEW_RELEASE) && rental.Value > 1)
                    frequentRenterPoints++;
                result += "\t" + rental.Key.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}