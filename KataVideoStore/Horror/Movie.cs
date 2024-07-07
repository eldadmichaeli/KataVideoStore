namespace KataVideoStore.Horror
{
    public class Movie
    {
        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int PriceCode { get; }
        public string Title { get; }
    }
}