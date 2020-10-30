using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class Meal
    {

        public int MealNumber { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }
         
        public double Price { get; set; }

        public Meal(int num)
        {
            MealNumber = num;
        }
    }
}
