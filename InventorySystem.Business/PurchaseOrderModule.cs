using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class PurchaseOrderModule
    {
        public PurchaseOrder GetPurchaseOrderById(int id)
        {
            return new PurchaseOrderManager().GetPurchaseOrderById(id);
        }

        public IOrderedEnumerable<PurchaseOrder> GetPurchaseOrders()
        {
            return new PurchaseOrderManager().GetPurchaseOrdes();
        }

        public PurchaseOrder Save(PurchaseOrder purchaseOrder)
        {
            return new PurchaseOrderManager().Save(purchaseOrder);
        }

        public int GetMaxId()
        {
            return new PurchaseOrderManager().GetMaxId();
        }

        public bool IsExist(int id)
        {
            return new PurchaseOrderManager().IsExist(id);
        }

        public bool Delete(int id)
        {
            return new PurchaseOrderManager().Delete(id);
        }
    }
}
