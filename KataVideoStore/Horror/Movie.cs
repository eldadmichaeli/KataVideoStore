namespace KataVideoStore.Horror
{
    public class Movie
    {
        private string _title;

        public Movie(string title, PriceCode priceCode)
        {
            _title = title;
            PriceCode = priceCode;
        }
        public PriceCode PriceCode { get; private set; }

        public string GetTitle() { return _title; }


    }
}