using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventorySystem.Data;

namespace InventorySystem.Business
{
    public class MembershipManager
    {
        private Membership PopulateReader(IDataReader dr)
        {
            Membership membership = new Membership();
            if (dr["Id"] != DBNull.Value)
                membership.Id = Convert.ToInt32(dr["Id"]);

            membership.Username = dr["Username"].ToString();
            membership.Password = dr["Password"].ToString();
            membership.Authorization = Convert.ToInt32(dr["Authorization"]);
            membership.EmployeeId = dr["EmployeeId"].ToString();
            return membership;
        }

        public Membership GetMembershipById(int id)
        {
            Membership membership = new Membership();
            using (MembershipDataAdapter adapter = new MembershipDataAdapter())
            {
                IDataReader dr = adapter.GetMembershipById(id);
                if (dr.Read())
                {
                    membership = PopulateReader(dr);    
                    adapter.Dispose();
                }
                return membership;
            }
            
        }

        public Membership GetMembershipByUsername(string username)
        {
            Membership membership = new Membership();
            using (MembershipDataAdapter adapter = new MembershipDataAdapter())
            {
                IDataReader dr = adapter.GetMembershipByUsername(username);
                if (dr.Read())
                {
                    membership = PopulateReader(dr);
                    adapter.Dispose();
                }
                return membership;
            }

        }

        public bool Insert(Membership membership)
        {
            using (MembershipDataAdapter adapter = new MembershipDataAdapter())
            {
                return adapter.InsertMembership(membership.Username, membership.Password,
                                                             membership.Authorization, membership.EmployeeId);
            }
        }
        public bool IsMembershipExist(int id)
        {
            bool exist = false;

            using (IDataReader dr = new MembershipDataAdapter().GetMembershipById(id))
            {
                if (dr.Read())
                    exist = true;

                dr.Close();
            }

            return exist;
        }

    }
}
