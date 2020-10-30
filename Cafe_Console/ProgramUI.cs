using Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private Menu_Repository _menuRepo = new Menu_Repository();

        public void Run()
        {
            SeedContent();
            Start();
            Menu();
        }

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string titlePage = @"

██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗ 
██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗
█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║
██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║
██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝
╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝ 
                                                      
 ██████╗ █████╗ ███████╗███████╗                      
██╔════╝██╔══██╗██╔════╝██╔════╝                      
██║     ███████║█████╗  █████╗                        
██║     ██╔══██║██╔══╝  ██╔══╝                        
╚██████╗██║  ██║██║     ███████╗                      
 ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝                      
                                                      
";
            Console.WriteLine(titlePage);
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        public void Menu()
        {

            bool responseIsValid = false;
            while (!responseIsValid)
            {

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

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
                        ShowMenu();
                        Console.ReadLine();
                        break;
                    case 2:
                        //Pick meal number
                        PickMealByNumber();
                        Console.ReadLine();
                        break;
                    case 3:
                        //Pick meal name
                        PickMealByName();
                        Console.ReadLine();
                        break;
                    case 4:
                        //Add new meal
                        AddMenuItem();
                        Console.ReadLine();
                        break;
                    case 5:
                        //Update
                        Console.Clear();
                        responseIsValid = true;
                        break;
                    case 6:
                        //delete menu item
                        RemoveMenuItem();
                        Console.ReadLine();
                        break;
                    case 7:
                        responseIsValid = true;
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
                "Grilled Onions, Chopped Lettuce, Bacon, Barbecue sauce on side, Brioche bun, and Two third-pound(before grilling) hamburger patties", 12.59);

            _menuRepo.AddMenuItem(burger);
        }
        
        public void ShowMenu()
        {
            Console.Clear();

            List<Menu> listOfMenu = _menuRepo.GetMenu();

            foreach(Menu meal in listOfMenu)
            {
                DisplayMenu(meal);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void AddMenuItem()
        {
            Console.Clear();

            Menu meal = new Menu();//new up a menu item and add it

            Console.WriteLine("Please enter a meal number");
            meal.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter a name for this meal");
            meal.Name = Console.ReadLine();

            Console.WriteLine("Please enter the description for this dish");
            meal.Description = Console.ReadLine();

            Console.WriteLine("Please enter the list of ingredients for this dish, separated by commas.");
            meal.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of your meal");
            meal.Price = Convert.ToDouble(Console.ReadLine());

            bool wasMade = _menuRepo.AddMenuItem(meal);
            if (wasMade == true)
            {
                Console.WriteLine("You have made a dish! You utter madlad");
            }
            else
            {
                Console.WriteLine("Give me your jacket and leave Hell's Kitchen!");
            }
        }

        public void PickMealByNumber()
        {
            Console.Clear();

            Console.WriteLine("Enter the number of the meal you wish to see.");
            int mealNum = Convert.ToInt32(Console.ReadLine());

            Menu meal = _menuRepo.GetMealByNumber(mealNum);
            if(meal != null)
            {
                DisplayMenu(meal);
            }
            else
            {
                Console.WriteLine("There are no meals by that number, sorry!");
            }
            Console.ReadKey();
        }

        public void PickMealByName()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the meal you wish to see.");
            string mealName = Console.ReadLine();

            Menu meal = _menuRepo.GetMealByName(mealName);
            if (meal != null)
            {
                DisplayMenu(meal);
            }
            else
            {
                Console.WriteLine("There are no meals by that name, sorry!");
            }
            Console.ReadKey();
        }

        public void RemoveMenuItem()
        {
            Console.Clear();

            ShowMenu();
            Console.WriteLine("Enter the name of the item you wish to yeet off this menu.");
            string name = Console.ReadLine();
            Menu meal = _menuRepo.GetMealByName(name);
            bool wasYote = _menuRepo.DeleteMealFromMenu(meal);
            if (wasYote)
            {
                Console.WriteLine("The meal was yote from our menu, with feeling.");
            }
            else
            {
                Console.WriteLine("Could not yeet the meal away. Try again.");
            }
        }

        private void DisplayMenu(Menu menu)//helper method
        {
            Console.WriteLine($"{menu.MealNumber}:  {menu.Name}");
            Console.WriteLine(menu.Description);
            Console.WriteLine($"Contains: {menu.Ingredients}");
            Console.WriteLine($"${menu.Price}");
        }
    }
}
