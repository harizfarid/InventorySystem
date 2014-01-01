using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Business
{
    public class PurchaseOrderManager
    {
        private CustomerCollection customerCollection = new CustomerManager().GetCustomers();
        private StatusCollection statusCollection = new StatusManager().GetStatus();
        public bool IsExist(int id)
        {
            using (PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter())
            {
                return adapter.IsExist(id);
            }
        }

        private PurchaseOrder PopulateReader(IDataReader dr)
        {
            PurchaseOrder po = new PurchaseOrder();

            if (dr["Id"] != null)
                po.Id = Convert.ToInt32(dr["Id"]);
            if (dr["customerId"] != null)
            {
                po.CustomerId = Convert.ToInt32(dr["customerId"]);
                po.CustomerInfo = customerCollection.FirstOrDefault(P => P.Id == po.CustomerId);
            }
            
            po.PONo = dr["PONo"].ToString();
            po.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
            po.Quantity = Convert.ToInt32(dr["Quantity"]);
            po.Price = Convert.ToDecimal(dr["Price"]);
            po.DeliveryDateTime = Convert.ToDateTime(dr["DeliveryDateTime"]);
            po.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
            po.CreatedBy = dr["CreatedBy"].ToString();
            if (dr["Status"] != null)
            {
                po.Status = Convert.ToInt32(dr["Status"]);
                po.StatusInfo = statusCollection.FirstOrDefault(P => P.Id == po.Status);
            }
            po.Remarks = dr["remarks"].ToString();

            return po;
        }

        public PurchaseOrder GetPurchaseOrderById(int id)
        {
            PurchaseOrder po = new PurchaseOrder();
            using (IDataReader dr = new PurchaseOrderDataAdapter().GetPurchaseOrderById(id))
            {
                if (dr.Read())
                {
                    po = PopulateReader(dr);
                }
            }
            return po;
        }

        public IOrderedEnumerable<PurchaseOrder> GetPurchaseOrdes()
        {
            PurchaseOrderCollection collection = new PurchaseOrderCollection();
            
            using (PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter())
            {
                IDataReader dr = adapter.GetPurchaseOrders();
                while (dr.Read())
                {
                    collection.Add(PopulateReader(dr));
                }
                dr.Dispose();
                adapter.Dispose();
            }
            return collection.OrderByDescending(P=>P.Id);
        }

        public PurchaseOrder Save(PurchaseOrder purchaseOrder)
        {
            using (PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter())
            {
                if (this.IsExist(purchaseOrder.Id))
                    adapter.UpdatePurchaseOrder(purchaseOrder.Id, purchaseOrder.CustomerId
                                                , purchaseOrder.PONo, purchaseOrder.DateCreated, purchaseOrder.Quantity
                                                , purchaseOrder.Remarks, purchaseOrder.Price,
                                                purchaseOrder.DeliveryDateTime
                                                , purchaseOrder.TotalPrice, purchaseOrder.CreatedBy,
                                                purchaseOrder.Status);
                else
                    adapter.InsertPurchaseOrder(purchaseOrder.CustomerId
                                , purchaseOrder.PONo, purchaseOrder.DateCreated, purchaseOrder.Quantity
                                , purchaseOrder.Remarks, purchaseOrder.Price,
                                purchaseOrder.DeliveryDateTime
                                , purchaseOrder.TotalPrice, purchaseOrder.CreatedBy,
                                purchaseOrder.Status);
            }

            return purchaseOrder;
        }

        public int GetMaxId()
        {
            using (PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter())
            {
                return adapter.GetMaxId();
            }
        }

        public bool Delete(int id)
        {
            using (PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter())
            {
                return adapter.DeletePurchaseOrder(id);
            }

        }

    }

}
