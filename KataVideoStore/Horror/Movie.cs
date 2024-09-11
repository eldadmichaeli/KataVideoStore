namespace KataVideoStore.Horror
{
    public class Movie
    {

        public string Title { get; }
        public PriceCodeType PriceCode { get; }

        public Movie(string title, PriceCodeType priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}