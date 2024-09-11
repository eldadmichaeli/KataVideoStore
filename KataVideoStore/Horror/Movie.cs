namespace KataVideoStore.Horror
{
    public class Movie
    {
        private string _title;
        private MovieType _priceCode;

        public Movie(string title, MovieType priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public MovieType GetPriceCode() { return _priceCode; }

        public void SetPriceCode(MovieType arg) { _priceCode = arg; }

        public string GetTitle() { return _title; }


    }
    public enum MovieType
    {
        REGULAR,
        NEW_RELEASE,
        CHILDRENS
    }
}