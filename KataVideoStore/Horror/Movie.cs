namespace KataVideoStore.Horror
{
    public class Movie
    {
        
        public Movie(string title, PriceCategory priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public PriceCategory PriceCode { get; }
      
        public string Title { get; }

    }
}