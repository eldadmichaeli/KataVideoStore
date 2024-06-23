using System;
using System.Collections.Generic;
using KataVideoStore.Dirty;

public class Customer
{
    private string name;
    private List<Rental> rentals = new List<Rental>();

    public Customer(string name)
    {
        this.name = name;
    }

    public void AddRental(Rental arg)
    {
        rentals.Add(arg);
    }

    public string GetName()
    {
        return name;
    }

    public string Statement()
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;
        string result = "Rental Record for " + GetName() + "\n";
        foreach (var each in rentals)
        {
            double thisAmount = 0;
            switch (each.GetMovie().GetPriceCode())
            {
                case Movie.CATEGORY_REGULAR:
                    thisAmount += 2;
                    if (each.GetDaysRented() > 2)
                        thisAmount += (each.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.CATEGORY_NEW_RELEASE:
                    thisAmount += each.GetDaysRented() * 3;
                    break;
                case Movie.CATEGORY_CHILDRENS:
                    thisAmount += 1.5;
                    if (each.GetDaysRented() > 3)
                        thisAmount += (each.GetDaysRented() - 3) * 1.5;
                    break;
            }
            frequentRenterPoints++;
            if ((each.GetMovie().GetPriceCode() == Movie.CATEGORY_NEW_RELEASE)
                && each.GetDaysRented() > 1)
                frequentRenterPoints++;
            result += "\t" + each.GetMovie().GetTitle() + "\t"
                      + thisAmount + "\n";
            totalAmount += thisAmount;
        }
        result += "Amount owed is " + totalAmount.ToString() + "\n";
        result += "You earned " + frequentRenterPoints.ToString()
                                + " frequent renter points";
        return result;
    }
}