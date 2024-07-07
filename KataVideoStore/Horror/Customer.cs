using KataVideoStore.Horror.Models;

namespace KataVideoStore.Horror
{
    using System.Collections.Generic;

    public class Customer
    {
        private Dictionary<Movie, int> rentals = new Dictionary<Movie, int>();

        public string Name { get; set; }
        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            rentals.Add(movie, daysRented);
        }


        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (var rental in rentals)
            {
                double thisAmount = 0;
                switch (rental.Key.PriceCode)
                {
                    case PriceCodeEnum.Regular:
                        thisAmount += 2;
                        if (rental.Value > 2)
                            thisAmount += (rental.Value - 2) * 1.5;
                        break;
                    case PriceCodeEnum.NewRelease:
                        thisAmount += rental.Value * 3;
                        break;
                    case PriceCodeEnum.Childrens:
                        thisAmount += 1.5;
                        if (rental.Value > 3)
                            thisAmount += (rental.Value - 3) * 1.5;
                        break;
                }
                frequentRenterPoints++;
                if ((rental.Key.PriceCode == PriceCodeEnum.NewRelease) && rental.Value > 1)
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