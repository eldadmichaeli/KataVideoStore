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
            customer.AddRental(new Movie("Star Wars", (int)MovieType.NEW_RELEASE), 6);
            customer.AddRental(new Movie("Sofia", (int)MovieType.CHILDREN), 7);
            customer.AddRental(new Movie("Inception", (int)MovieType.REGULAR), 5);

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
