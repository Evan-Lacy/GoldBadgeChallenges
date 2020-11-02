using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repo
{
    public class Badges_Repository
    {
       
        private Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        //CRUD

        //Create
        public bool CreateNewBadge(Badge badge)
        {
            int startingCount = _dictionary.Count;

            //Badge badge = new Badge(id, rooms);
            _dictionary.Add(badge.BadgeID, badge.RoomAccess);

            bool wasAdded = (_dictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public Dictionary<int, List<string>> ListAllBadges()
        {
            return _dictionary;

        }

        public Badge GetBadgeByID(int idNum)
        {
            if (_dictionary.ContainsKey(idNum))
            {
                Badge badge = new Badge(idNum);
                badge.RoomAccess = _dictionary[idNum];
                return badge;
            }
            return null;
        }

        //Update
        public bool UpdateBadge(int oldID, Badge newBadge)
        {
            Badge old = GetBadgeByID(oldID);

            if (old != null)//cause if the old badge id number is not there,then I can't remove it
            {
                old.BadgeID = newBadge.BadgeID;//set the old things equal to the new things
                old.RoomAccess = newBadge.RoomAccess;
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        //Delete

        public bool DeletingBadge(Badge badge)
        {
            bool deletedBadge = _dictionary.Remove(badge.BadgeID);
            return deletedBadge;
        }


    }
}
