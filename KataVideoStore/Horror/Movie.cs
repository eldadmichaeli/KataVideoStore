using KataVideoStore.Horror.Models;

namespace KataVideoStore.Horror
{
    public class Movie
    {


        private string _title;
        private PriceCode _priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public PriceCode GetPriceCode() { return _priceCode; }

        public void SetPriceCode(PriceCode arg) { _priceCode = arg; }

        public string GetTitle() { return _title; }


    }
}