using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class StatusModule
    {
        public Status GetStatusById(int id)
        {
            return new StatusManager().GetStatusById(id);
        }

        public StatusCollection GetStatus()
        {
            return new StatusManager().GetStatus();
        }

        public List<LookupEntity> GetStatusLookUp()
        {
            StatusCollection status = this.GetStatus();
            List<LookupEntity> lookUps = new List<LookupEntity>();
            foreach (Status st in status)
            {
                lookUps.Add(new LookupEntity(st.Id.ToString(), st.Name));
            }
            lookUps.OrderBy(P => P.Name);
            return lookUps;
        }
    }
}
