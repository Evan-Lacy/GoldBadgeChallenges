using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {

        public void Run()
        {
            Start();
        }

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            string titlePage = @"

            ██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗                
            ██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗               
            █████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║               
            ██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║               
            ██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝               
            ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝                
                                                                                 
██████╗ ██████╗  ██████╗ ████████╗███████╗ ██████╗████████╗██╗ ██████╗ ███╗   ██╗
██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║
██████╔╝██████╔╝██║   ██║   ██║   █████╗  ██║        ██║   ██║██║   ██║██╔██╗ ██║
██╔═══╝ ██╔══██╗██║   ██║   ██║   ██╔══╝  ██║        ██║   ██║██║   ██║██║╚██╗██║
██║     ██║  ██║╚██████╔╝   ██║   ███████╗╚██████╗   ██║   ██║╚██████╔╝██║ ╚████║
╚═╝     ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚══════╝ ╚═════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
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

                Console.WriteLine("Good Morning Admin. To what do I owe this pleasure?\n" +
                    "Would you like to select an option?\n" +
                    "1. Add a badge\n" +
                    "2. Update a Badge\n" +
                    "3. List all badges in my directory\n" +
                    "4. Delete obsolete badges" +
                    "5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("I'm sorry, you seem to have put in the wrong command.\n" +
                            " Please do try again, I'm sure you'll get it this time.");
                        break;
                }
            }
        }
    }
}
