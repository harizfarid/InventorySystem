using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class Cast
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Material { get; set; }

        public int Weight { get; set; }

        public decimal OriginalCost { get; set; }

        public decimal ModificationCost { get; set; }

        public decimal TotalCost { get; set; }

        public string Remarks { get; set; }

        public string Others { get; set; }
    }
}
