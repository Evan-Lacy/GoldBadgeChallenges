using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class Menu_Repository
    {
        private List<Menu> _menu = new List<Menu>();
        //CRUD

        //Create new menu items
        public bool AddMenuItem(Menu menu)
        {
            int menuCount = _menu.Count;

            _menu.Add(menu);

            bool wasAdded = (_menu.Count > menuCount) ? true : false;
            return wasAdded;
        }
        //Read
        //Get all menu items
        public List<Menu> GetMenu()
        {
            return _menu;
        }
        //Get menu items by number
        public Menu GetMealByNumber(int num)
        {
            foreach (Menu meal in _menu)
            {
                if (meal.MealNumber == num)
                {
                    return meal;
                }
            }
            return null;
        }
        //Get menu items by name
        public Menu GetMealByName(string name)
        {
            foreach (Menu meal in _menu)
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
        //Get meal ingredients

        //Update
        //not done yet

        //Delete
        //Remove a menu item by name
        public bool DeleteMealFromMenu(string menuItem)
        {
            foreach (Menu meal in _menu)
            {
                if (meal.Name.ToLower() == menuItem.ToLower())
                {
                    bool deleteResult = _menu.Remove(meal);
                    return deleteResult;

                }

            }
            return false;
        }
    }
}
