namespace KataVideoStore.Horror
{
    public class Movie
    {
        public const int Children = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;
        public string Title { get; }
        public int PriceCode { get; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}