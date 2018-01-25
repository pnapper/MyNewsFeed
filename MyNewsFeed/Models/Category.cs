using System;
using System.Collections.Generic;

namespace MyNewsFeed.Models
{
    public class Category
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }

        public Category(string Title, string CategoryName)
        {
            this.Title = Title;
            this.CategoryName = CategoryName;
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category("All", ""));
            categories.Add(new Category("Business", "Business"));
            categories.Add(new Category("Entertainment", "Entertainment"));
            categories.Add(new Category("General", "General"));
            categories.Add(new Category("Health", "Health"));
            categories.Add(new Category("Science", "Science" ));
            categories.Add(new Category("Sports", "Sports"));
            categories.Add(new Category("Technology", "Technology"));
          
            return categories;
        }
    }
}

