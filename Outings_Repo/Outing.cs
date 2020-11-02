using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repo
{
    public enum EventType { AmusementPark = 1, Bowling, Concert, Golf}
    public class Outing
    {
        public int Attendance { get; set; }

        public EventType Type { get; set; }

        public DateTime Date { get; set; }

        public decimal EventCost { get; set; }

        public decimal CostPerAttendee
        {
            get
            {
                decimal cpa = EventCost / Attendance;
                decimal total = Decimal.Round(cpa, 2);
                return total;
            }
        }

        public Outing() { }

        public Outing(int customers, EventType type, DateTime date, decimal cost)
        {
            Attendance = customers;
            Type = type;
            Date = date;
            EventCost = cost;
        }
    }
}
