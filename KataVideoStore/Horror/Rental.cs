namespace KataVideoStore.Horror
{
    public class Rental
    {
        private const double Coefficient = 1.5;
        private const int Two = 2;
        private const int Three = 3;
        public Movie Movie { get; }
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            _daysRented = daysRented;
        }

        public double GetCharge()
        {
            switch (Movie.PriceCode)
            {
                case PriceCodeType.Regular:
                    return CalculatePrice(Two, Two);
                case PriceCodeType.NewRelease:
                    return _daysRented * Three;
                case PriceCodeType.Children:
                    return CalculatePrice(Three, Coefficient);
                default:
                    return 0;
            }
        }
        
        private double CalculatePrice(int rented, double coefficient) =>
            _daysRented > rented ? coefficient + (_daysRented - rented) * Coefficient : coefficient;
        
        public int GetFrequentRenterPoints() => 
            Movie.PriceCode == PriceCodeType.NewRelease && _daysRented > 1 ? 2 : 1;
    }
}