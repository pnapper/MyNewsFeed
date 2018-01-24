using System;
using System.Collections.Generic;

namespace MyNewsFeed.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Country(string Name, string Symbol)
        {
            this.Name = Name;
            this.Symbol = Symbol;
        }

        public static List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country("United States", "us"));
            countries.Add(new Country("Argentina", "ar"));
            countries.Add(new Country("Australia", "au"));
            countries.Add(new Country("Hong Kong", "hk"));
            countries.Add(new Country("Canada", "ca"));
            countries.Add(new Country("China", "cn"));
            countries.Add(new Country("France", "fr"));
            countries.Add(new Country("Germany", "de"));
            countries.Add(new Country("India", "in"));
            countries.Add(new Country("Indonesia", "id"));
            countries.Add(new Country("Italy", "it"));
            countries.Add(new Country("Philippines", "ph"));
            countries.Add(new Country("Switzerland", "ch"));
            countries.Add(new Country("United Kingdom", "gb"));

            return countries;
        }
    }
}
