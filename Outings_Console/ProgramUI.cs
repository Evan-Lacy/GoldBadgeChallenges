using Outings_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Console
{
    public class ProgramUI
    {
        private Outing_Repository _repo = new Outing_Repository();


        public void Run()
        {
            SeedContent();
            TitleScreen();
            Menu();
        }

        public void TitleScreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            string title = @"
      ██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗            
      ██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗           
      █████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║           
      ██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║           
      ██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝           
      ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝            
                                                                     
     ██████╗ ██╗   ██╗████████╗██╗███╗   ██╗ ██████╗ ███████╗        
    ██╔═══██╗██║   ██║╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝        
    ██║   ██║██║   ██║   ██║   ██║██╔██╗ ██║██║  ███╗███████╗        
    ██║   ██║██║   ██║   ██║   ██║██║╚██╗██║██║   ██║╚════██║        
    ╚██████╔╝╚██████╔╝   ██║   ██║██║ ╚████║╚██████╔╝███████║        
     ╚═════╝  ╚═════╝    ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝        ";
            Console.WriteLine(title);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        public void SeedContent()
        {
            Outing outing1 = new Outing(500, EventType.Bowling, DateTime.Now, 1450.99m);
            Outing outing2 = new Outing(200, EventType.AmusementPark, new DateTime(2020, 10, 25), 1120.57m);
            Outing outing3 = new Outing(50, EventType.Golf, new DateTime(2020, 09, 01), 1350.99m);
            Outing outing4 = new Outing(175, EventType.Concert, new DateTime(2020, 01, 20), 2350.99m);
            Outing outing5 = new Outing(230, EventType.Concert, new DateTime(2020, 07, 15), 2270.85m);
            Outing outing6 = new Outing(32, EventType.Golf, new DateTime(2020, 05, 17), 1123.58m);
            Outing outing7 = new Outing(28, EventType.Golf, new DateTime(2020, 06, 04), 1234.56m);
            Outing outing8 = new Outing(50, EventType.Bowling, new DateTime(2020, 10, 19), 1600.82m);
            _repo.AddNewOuting(outing1);
            _repo.AddNewOuting(outing2);
            _repo.AddNewOuting(outing3);
            _repo.AddNewOuting(outing4);
            _repo.AddNewOuting(outing5);
            _repo.AddNewOuting(outing6);
            _repo.AddNewOuting(outing7);
            _repo.AddNewOuting(outing8);
        }

        public void Menu()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            bool whileRunning = true;
            while (whileRunning)
            {

                Console.Clear();

                Console.WriteLine("Salutations, User! How may I be of service to our great company of Komodo?\n" +
                    "1. Add a new outing.\n" +
                    "2. Show all outings this year.\n" +
                    "3. Calculate the total cost for all outings.\n" +
                    "4. Calculate the cost of each type of outing.\n" +
                    "5. Exit");
                int response = Convert.ToInt32(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        //Add outing
                        AddOuting();
                        break;
                    case 2:
                        //Show all outings
                        ShowAllOutings();
                        break;
                    case 3:
                        //Calculate total cost
                        CalculateTotalCost();
                        break;
                    case 4:
                        //calculate cost per type
                        CostsByType();
                        break;
                    case 5:
                        whileRunning = false;
                        break;
                }
            }
        }

        public void AddOuting()
        {
            Console.Clear();

            Outing newOuting = new Outing();

            Console.WriteLine("Please enter the number of Attendees:");
            newOuting.Attendance = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the event type:\n" +
                "1. Amusement Park.\n" +
                "2. Bowling.\n" +
                "3. Concert.\n" +
                "4. Golf.");
            newOuting.Type = (EventType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the date of the event (yyyy-mm-dd):");
            newOuting.Date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the total cost of the event:");
            newOuting.EventCost = Convert.ToDecimal(Console.ReadLine());

            _repo.AddNewOuting(newOuting);
        }

        public void ShowAllOutings()
        {
            Console.Clear();

            List<Outing> listOfOutings = _repo.GetOutings();

            foreach(Outing outing in listOfOutings)
            {
                DisplayOutings(outing);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public decimal CalculateTotalCost()
        {
            Console.Clear();
            List<Outing> listOfOutings = _repo.GetOutings();
            //List<decimal> listOfCosts = new List<decimal>();
            decimal totalCost = 0.0m;

            foreach(Outing outing in listOfOutings)
            {
                totalCost = _repo.CombinedCost();
            }
            Console.WriteLine($"The total cost of all events is:    {totalCost}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return totalCost;
        }

        public decimal CostsByType()
        {
            Console.Clear();
            List<Outing> listOfOutings = _repo.GetOutings();
            Outing outin = new Outing();
            //List<decimal> listOfCosts = new List<decimal>();
            decimal totalCost = 0.0m;
            Console.WriteLine("What outing type would you like to sum up?\n" +
                "1. Amusement Park.\n" +
                "2. Bowling.\n" +
                "3. Concert.\n" +
                "4. Golf.");
            int response = Convert.ToInt32(Console.ReadLine());
            switch (response)
            {
                case 1:
                    totalCost = _repo.CostsByType(EventType.AmusementPark);
                    break;
                case 2:
                    totalCost = _repo.CostsByType(EventType.Bowling);

                    break;
                case 3:
                    totalCost = _repo.CostsByType(EventType.Concert);

                    break;
                case 4:
                    totalCost = _repo.CostsByType(EventType.Golf);
                    break;
            }

            Console.WriteLine($"The total cost of all events is:    {totalCost}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return totalCost;
        }

        public void DisplayOutings(Outing outing)
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-     Event     -=-=-=-=-=-=-=-=");
            Console.WriteLine($"Number of Attendees:    {outing.Attendance}");
            Console.WriteLine($"Type of Event:          {outing.Type}");
            Console.WriteLine($"Date of the Event:      {outing.Date}");
            Console.WriteLine($"Total cost of Event:    {outing.EventCost}");
            Console.WriteLine($"Cost per Attendee:      {outing.CostPerAttendee}");
        }
    }
}
