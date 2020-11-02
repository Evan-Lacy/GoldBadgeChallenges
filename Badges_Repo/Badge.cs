using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repo
{
    public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> RoomAccess { get; set; }

        public Badge() { }

        public Badge(int id)
        {
            BadgeID = id;
        }

        public Badge(int badgeId, List<string> access)
        {
            BadgeID = badgeId;
            RoomAccess = access;
        }
    }
}
