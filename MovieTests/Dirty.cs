using KataVideoStore.Dirty;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace MovieTests
{
    [TestClass]
    public class Dirty
    {
        [TestMethod]
        public void CharacterizationTest()
        {
            Customer customer = new Customer("John Doe");
            customer.AddRental(new Rental(new Movie("Star Wars", Movie.CATEGORY_NEW_RELEASE), 6));
            customer.AddRental(new Rental(new Movie("Sofia", Movie.CATEGORY_CHILDRENS), 7));
            customer.AddRental(new Rental(new Movie("Inception", Movie.CATEGORY_REGULAR), 5));

            string expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }
    }
}