using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class LookupEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public LookupEntity()
        {}

        public LookupEntity(string id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
