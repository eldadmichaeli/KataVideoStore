using System;
using System.Data;

namespace KataVideoStore.Dirty
{
    public class Movie
    {
        public const int CATEGORY_CHILDRENS = 2;
        public const int CATEGORY_REGULAR = 0;
        public const int CATEGORY_NEW_RELEASE = 1;
        private string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public void SetPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}