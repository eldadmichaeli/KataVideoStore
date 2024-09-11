using System.Text;

namespace KataVideoStore.Horror
{
    public class Customer
    {
        private const string RentalRecordLine = "Rental Record for ";
        private const string AmountLine = "Amount owed is ";
        private const string EarnedLine = "You earned {0} frequent renter points";
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

            result.Append($"{RentalRecordLine}{Name}\n");
            result.Append(_rentalOrder.PrintRentals());
            double totalAmount = _rentalOrder.CalculateTotalPrice();
            int frequentRenterPoints = _rentalOrder.CalculateFrequentRentalPoints();

            result.Append($"{AmountLine}{totalAmount}\n");
            result.AppendFormat(EarnedLine, frequentRenterPoints);

            return result.ToString();
        }
    }
}