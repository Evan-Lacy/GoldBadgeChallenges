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
        public int MealNumber { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public double Price { get; set; }

        //empty constructor
        public Menu() { }

        //overloaded/full constructor
        public Menu(int num, string name, string description, List<string> ingredients, double price)
        {
            MealNumber = num;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
