using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventorySystem.Data;

namespace InventorySystem.Business
{
    public class StatusManager
    {
        private Status PopulateReader(IDataReader dr)
        {
            Status status = new Status();

            if (dr["Id"] != null)
                status.Id = Convert.ToInt32(dr["Id"]);
            status.Name = dr["Name"].ToString();

            return status;
        }

        public Status GetStatusById(int id)
        {
            Status status = new Status();
            using (StatusDataAdapter adapter = new StatusDataAdapter())
            {
                IDataReader dr = adapter.GetStatusById(id);
                if (dr.Read())
                {
                    status = PopulateReader(dr);
                    dr.Dispose();
                }

                adapter.Dispose();
                return status;
            }

        }

        public StatusCollection GetStatus()
        {
            StatusCollection status = new StatusCollection();
            using (StatusDataAdapter adapter = new StatusDataAdapter())
            {
                IDataReader dr = adapter.GetStatus();
                while (dr.Read())
                {
                    status.Add(PopulateReader(dr));
                } 
                dr.Dispose();
                adapter.Dispose();
                return status;
            }

        }
    }
}