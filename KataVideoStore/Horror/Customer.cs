using System.Text;

namespace KataVideoStore.Horror
{
    public class Customer
    {
        private string Name { get; }
        private readonly RentalOrder _rentalOrder;

        public Customer(string name)
        {
            Name = name;
            _rentalOrder = new RentalOrder();
        }

        public void AddRental(Rental rental)
        {
            _rentalOrder.AddRental(rental);
        }

        public string CalculateStatement()
        {
            var result = new StringBuilder();

            result.Append($"Rental Record for {Name}\n");
            result.Append(_rentalOrder.PrintRentals());
            double totalAmount = _rentalOrder.CalculateTotalPrice();
            int frequentRenterPoints = _rentalOrder.CalculateFrequentRentalPoints();

            result.Append($"Amount owed is {totalAmount}\n");
            result.Append($"You earned {frequentRenterPoints} frequent renter points");

            return result.ToString();
        }
    }
}