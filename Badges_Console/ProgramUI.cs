using Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {

        private Badges_Repository _badgeRepo = new Badges_Repository();

        public void Run()
        {
            SeedContent();
            Start();
            Menu();
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
                    "4. Delete all items from a badge\n" +
                    "5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Add a badge
                        MakeABadge();
                        break;
                    case 2:
                        //Update a badge
                        UpdateABadge();
                        break;
                    case 3:
                        //List all badges
                        ShowAllBadges();
                        break;
                    case 4:
                        DeleteBadges();
                        break;
                    case 5:
                        responseIsValid = true;
                        break;
                    default:
                        Console.WriteLine("I'm sorry, you seem to have put in the wrong command.\n" +
                            " Please do try again, I'm sure you'll get it this time.");
                        break;
                }
            }
        }

        public void MakeABadge()
        {
            Console.Clear();

            List<string> doors = new List<string>();
            Badge badge = new Badge();

            Console.WriteLine("What is the number on the badge?\n");
            int id = Convert.ToInt32(Console.ReadLine());

            badge.BadgeID = id;
            //error catch for multiple badge ids

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("List a door that badge needs access to:\n");
                doors.Add(Console.ReadLine());

                Console.WriteLine("Any other doors this badge needs access to? Yes or No");
                string decision = Console.ReadLine().ToLower();
                //if(decision == "yes")
                //{
                //    break;
                //}
                if (decision == "no")
                {
                    addingDoors = false;
                    break;
                }
                //else
                //{
                //    Console.WriteLine("Yes or No answer only, please. We have no time for games");

                //}

            }
            badge.RoomAccess = doors;
            _badgeRepo.CreateNewBadge(badge);

            Console.WriteLine("Press ENTER to return to Main Menu.");
            Console.ReadLine();
        }

        public void UpdateABadge()
        {
            Console.Clear();

            Console.WriteLine("What is the badge ID would you like to update?\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Badge badgeToFix = _badgeRepo.GetBadgeByID(id); //create a new object of a badge and assign it to a variable, after getting the info via ID number
            List<string> doors = new List<string>();
            if (badgeToFix != null)
            {
                doors = badgeToFix.RoomAccess;//populate my list 'doors' with the all the doors assigned to that badge
                bool fixingDoors = true;
                while (fixingDoors)
                {
                    Console.Clear();
                    string totalDoors = string.Join(",", badgeToFix.RoomAccess); //Need to make all individual strings in this list one string
                    Console.WriteLine($"{badgeToFix.BadgeID} has access to doors {totalDoors}"); //print out the badge info right here

                    Console.WriteLine("What would you like to do?\n" +
                        "1. Add a door.\n" +
                        "2. Remove a door\n" +
                        "3. Return to main menu.\n");
                    int response = Convert.ToInt32(Console.ReadLine());

                    switch (response)//need to check what number in the submenu they use
                    {
                        case 1:
                            Console.WriteLine("Which door would you like to add?\n");
                            string doorToAdd = Console.ReadLine(); //get their answer
                            doors.Add(doorToAdd);//add that door to the list of doors
                            badgeToFix.RoomAccess = doors; //add that list of doors to the doors associated with the badge being operated on
                            string doorsOnBadge = string.Join(",", badgeToFix.RoomAccess);
                            Console.WriteLine($"{badgeToFix.BadgeID} has access to doors {doorsOnBadge}");
                            Console.WriteLine("Press any key to conitnue...");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Which door would you like to remove?\n");
                            string doorToRemove = Console.ReadLine();
                            doors.Remove(doorToRemove);
                            badgeToFix.RoomAccess = doors;
                            doorsOnBadge = string.Join(",", badgeToFix.RoomAccess);
                            Console.WriteLine($"{badgeToFix.BadgeID} has access to doors {doorsOnBadge}");
                            Console.WriteLine("Press any key to conitnue...");
                            Console.ReadKey();
                            break;
                        case 3:
                            fixingDoors = false;
                            break;
                    }
                }
                bool isFixed = _badgeRepo.UpdateBadge(id, badgeToFix);
                if (isFixed == true)
                {
                    Console.WriteLine("It has been done, my Lord");
                }
                else
                {
                    Console.WriteLine("Nah, nice try you hacker.");
                }

            }
            else
            {
                Console.WriteLine("Badge ID not found, please try again");
            }
                
                Console.WriteLine("Press ENTER to return to Main Menu.");
                Console.ReadLine();
        }

        public void DeleteBadges()
        {
            Console.Clear();

            Console.WriteLine("What is the badge ID would you like to delete?\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Badge badgeToYeet = _badgeRepo.GetBadgeByID(id);
            List<string> doors = new List<string>();

            if (badgeToYeet != null)
            {
                doors = badgeToYeet.RoomAccess;
                string allDoors = string.Join(",", badgeToYeet.RoomAccess);
                Console.WriteLine($"Badge {id} has access to these doors: {allDoors}");
                Console.WriteLine("Would you like to delete these doors off this badge? (Yes/No)");
                string cyberman = Console.ReadLine().ToLower();
                if(cyberman == "yes")
                {
                    badgeToYeet.RoomAccess.Clear();
                    bool wasYote = _badgeRepo.UpdateBadge(id, badgeToYeet);
                    if (wasYote == true)
                    {
                        Console.WriteLine("It has been yote, Sir.");
                    } else
                    {
                        Console.WriteLine("It did not work, try again.");
                    }
                    
                } else
                {
                    Console.WriteLine("Guess it isn't meant to be. Sorry.");
                }
            }
            Console.WriteLine("Press ENTER to return to Main Menu.");
            Console.ReadLine();
        }

        public void SeedContent()
        {
            List<string> multipass = new List<string>() {
                "A1", "A2", "A3", "A4", "A5",
                "B1", "B2", "B3", "B4", "B5",
                "C1", "C2", "C3", "C4", "C5",};
            int id = 1;

            Badge badge = new Badge(id, multipass);

            _badgeRepo.CreateNewBadge(badge);
        }

        public void ShowAllBadges()
        {
            Console.Clear();

            Console.WriteLine("Badge #          Door Access\n");
            Dictionary<int, List<string>> listOfBadges = _badgeRepo.ListAllBadges();

            foreach (KeyValuePair<int, List<string>> badges in listOfBadges)
            {
                string doors = string.Join(", ", badges.Value);
                Console.WriteLine($"{badges.Key}         {doors}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
