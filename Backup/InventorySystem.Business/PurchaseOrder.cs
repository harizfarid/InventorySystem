using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string PONo { get; set; }

        public DateTime DateCreated { get; set; }

        public int Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal Price { get; set; }

        public DateTime DeliveryDateTime { get; set; }

        public decimal TotalPrice { get; set; }

        public string CreatedBy { get; set; }

        public int Status { get; set; }

        public Customer CustomerInfo { get; set; }

        public Status StatusInfo { get; set; }    

    }
}
