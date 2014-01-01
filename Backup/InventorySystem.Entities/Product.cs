using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Entities
{
    public partial class Product
    {
        public String CustomerName { get; set; }
        public String SupplierName { get; set; }
        public String ProductGroupName { get; set; }

        public void LoadCustomer(int customerId)
        {
            using (InventorySystemMaintenanceEntities ctx = new InventorySystemMaintenanceEntities())
            {
                if (customerId!= 0)
                {
                    CustomerName = ctx.Customer.FirstOrDefault(P => P.Id == customerId).Name;
                }
            }
        }

        public void LoadSupplier(int supplierId)
        {
            using (InventorySystemMaintenanceEntities ctx = new InventorySystemMaintenanceEntities())
            {
                if (supplierId != 0)
                {
                    SupplierName = ctx.Supplier.FirstOrDefault(P => P.Id == supplierId).Name;
                }
            }
        }

        public void LoadProductGroupName(int groupId)
        {
            using (InventorySystemMaintenanceEntities ctx = new InventorySystemMaintenanceEntities())
            {
                if (groupId != 0)
                {
                    ProductGroupName = ctx.ProductGroup.FirstOrDefault(P => P.Id == groupId).Name;
                }
            }
        }
    }
}
