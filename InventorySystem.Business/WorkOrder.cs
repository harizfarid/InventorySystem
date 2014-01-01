using System;

namespace InventorySystem.Business
{

    public class WorkOrder
    {
        private Customer _customer;
        private Material _material;

        public int Id { get; set; }
        public int CustomerId { get; set; }


        public Customer Customer
        {
            get
            {
                if (this.CustomerId != null)
                    _customer = new CustomerModule().GetCustomerById(this.CustomerId);
                    return _customer;
            }
            set { _customer = value; }
        }

        public Material Material
        {
            get
            {
                if (this.MaterialId != null)
                    _material = new MaterialModule().GetMaterial(this.MaterialId);

                return _material;
            }
        }

        public string Description { get; set; }
        public string MaterialId { get; set; }

        public int Quantity { get; set; }

        public int CastingWeight { get; set; }

        public decimal PatternCost { get; set; }

        public decimal MachiningCost { get; set; }

        public decimal ModificationCost { get; set; }

        public decimal TotalCost { get; set; }

        public string Others { get; set; }

        public DateTime DeliveryDateTime { get; set; }

        public string Remarks { get; set; }

        public string CustomerName { get; set; }

        public void Save()
        {
            WorkOrderManager workOrderManager = new WorkOrderManager();
            if (!workOrderManager.IsWorkOrderExist(Id))
            {
                workOrderManager.Insert(this);
            }
            else
                workOrderManager.Update(this);

        }


    }
}
