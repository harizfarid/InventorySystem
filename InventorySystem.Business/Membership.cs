using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class Membership
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Authorization { get; set; }
        public string EmployeeId { get; set; }


        public void Save()
        {
            MembershipManager membershipManager = new MembershipManager();
            if (!membershipManager.IsMembershipExist(Id))
            {
                membershipManager.Insert(this);
            }

        }
    }
}
