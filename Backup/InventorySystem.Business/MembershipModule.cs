using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class MembershipModule
    {
        public Membership GetMembershipById(int id)
        {
            return new MembershipManager().GetMembershipById(id);
        }

        public Membership GetMembershipByUsername(string username)
        {
            return new MembershipManager().GetMembershipByUsername(username);
        }


        public void Save(Membership membership)
        {
            membership.Save();
        }
    }
}
