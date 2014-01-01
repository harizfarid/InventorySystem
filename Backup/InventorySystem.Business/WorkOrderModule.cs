using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class WorkOrderModule
    {
        public WorkOrder GetWorkOrder(int id)
        {
            return new WorkOrderManager().GetWorkOrder(id);
        }

        public void Save(WorkOrder workOrder)
        {
            workOrder.Save();
        }

        public bool Delete(int id)
        {
            return new WorkOrderManager().Delete(id);
        }

        public WorkOrderCollection GetWorkOrders()
        {
            return new WorkOrderManager().GetWorkOrders();
        }

        public WorkOrderCollection GetWorkOrdersByCustomerName(string name)
        {
            return new WorkOrderManager().GetWorkOrdersByCustomerName(name);
        }

        public int GetMaxId()
        {
            return new WorkOrderManager().GetMaxId();
        }

        public WorkOrderCollection GetTop5Materials()
        {
            return new WorkOrderManager().GetTop5Materials();
        }

        public WorkOrderCollection GetTop5Customers()
        {
            return new WorkOrderManager().GetTop5Customers();
        }

        public WorkOrderCollection GetTop5WorkOrders()
        {
            return new WorkOrderManager().GetTop5WorkOrders();
        }
    }



}
