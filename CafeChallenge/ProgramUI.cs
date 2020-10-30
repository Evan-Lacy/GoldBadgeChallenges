using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI
{
    public class ProgramUI
    {

        public void Run()
        {

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
            }
        }

    }
}
