using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KataVideoStore.Horror;


namespace MovieTests
{
    [TestClass]
    public class Horror
    {
        [TestMethod]
        public void CharacterizationTest()
        {

            KataVideoStore.Horror.Customer customer = new KataVideoStore.Horror.Customer("John Doe");
            customer.AddRental(new Movie("Star Wars", PriceCategory.NewRelease), 6);
            customer.AddRental(new Movie("Sofia", PriceCategory.Childrens), 7);
            customer.AddRental(new Movie("Inception", PriceCategory.Regular), 5);

            string expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }

        [TestMethod]
        public void RentingRegularMovieForMoreThanAllowedDaysResultsInLateFee()
        {
            var expectedRate = 6.5;
            var actualRate = Customer.GetTotalRentalPricePerMovie(new Movie("Inception", PriceCategory.Regular), 5);
            
            Assert.AreEqual(actualRate, expectedRate);
        }
    }
}
