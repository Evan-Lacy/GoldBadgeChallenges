using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class Menu
    {
        //properties
        public int MealNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public double Price { get; set; }

        //empty constructor
        public Menu() { }

        //overloaded/full constructor
        public Menu(int num, string name, string description, string ingredients, double price)
        {
            MealNumber = num;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
