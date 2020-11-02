using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repo
{
    public class Outing_Repository
    {

        private List<Outing> _outing = new List<Outing>();

        //CRUD

        //Create
        public bool AddNewOuting(Outing outingFun)
        {
            int startingOuting = _outing.Count();
            _outing.Add(outingFun);

            bool wasAdded = (_outing.Count > startingOuting) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Outing> GetOutings()
        {
            return _outing;
        }
        
        public decimal CombinedCost() //calculate total cost of all outings
        {
            decimal billyIdol = 0.0m;
            //all outings added together
            foreach(Outing foo in _outing)
            {
                //take foo
                //add EventCost to billyIdol
                billyIdol += foo.EventCost;

            }
            return billyIdol;
        }

        public decimal CostsByType(EventType type)
        {
            decimal total = 0.0m;
            foreach(Outing fighters in _outing)
            {
                if(fighters.Type == type)
                {
                    total += fighters.EventCost;
                }
            }
            return total;
        }
        //Update calculations are not updates

        //Delete no need

    }
}
