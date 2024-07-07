using KataVideoStore.Horror.Models;

namespace KataVideoStore.Horror
{
    public class Movie
    {
        public PriceCodeEnum PriceCode { get; set; }
        public string Title { get; private set; }

        public Movie(string title, PriceCodeEnum priceCodeEnum)
        {
            Title = title;
            PriceCode = priceCodeEnum;
        }
        
    }
}