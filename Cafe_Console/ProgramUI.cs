using Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private Menu_Repository _menuRepo = new Menu_Repository();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void Menu()
        {

            bool responseIsValid = false;
            while (!responseIsValid)
            {

                Console.WriteLine("Select an Option:\n" +
                    "1. See the whole menu\n" +
                    "2. Pick a meal by number\n" +
                    "3. Pick a meal by name\n" +
                    "4. Add a new menu item\n" +
                    "5. Update a menu item [Under Construction]\n" +
                    "6. Remove a menu item\n" +
                    "7. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //See all menu
                        break;
                    case 2:
                        //Pick meal number
                        break;
                    case 3:
                        //Pick meal name
                        break;
                    case 4:
                        //Add new meal
                        break;
                    case 5:
                        //Update
                        break;
                    case 6:
                        //delete menu item
                        break;
                    default:
                        Console.WriteLine("I'm sorry, Dave. I'm afraid I can't let you do that.");
                        break;
                }
            }
        }

        public void SeedContent()
        {
            Menu burger = new Menu(1, "Evan's Bacon Burger", "One of Chef Evan's favorite designs, two flame grilled patties on a toasted brioche bun with onions, lettuce, and lots of bacon",
                ["Grilled Onions", "Chopped Lettuce", "Bacon", "Barbecue sauce on side", "Brioche bun","Two third-pound(before grilling) hamburger patties"], 12.59);

            _menuRepo.AddMenuItem(burger);
        }
    }
}
