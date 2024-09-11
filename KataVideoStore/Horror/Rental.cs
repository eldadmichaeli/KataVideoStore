namespace KataVideoStore.Horror
{
    public class Rental
    {
        public Movie Movie { get; set; }
        public int Days { get; set; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            Days = daysRented;
        }
    }
}
