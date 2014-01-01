using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
