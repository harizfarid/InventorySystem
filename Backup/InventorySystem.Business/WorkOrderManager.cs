using System;
using InventorySystem.Data;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Business
{
    public class WorkOrderManager
    {
        public WorkOrderCollection GetWorkOrders()
        {
            WorkOrderCollection workOrderCollection = new WorkOrderCollection();
            using (IDataReader dr = new WorkOrderDataAdapter().GetWorkOrders())
            {
                while (dr.Read())
                {
                    workOrderCollection.Add(PopulateReader(dr));
                }
                dr.Close();
            }
            return workOrderCollection;
        }

        public WorkOrderCollection GetTop5WorkOrders()
        {
            WorkOrderCollection workOrderCollection = new WorkOrderCollection();
            using (IDataReader dr = new WorkOrderDataAdapter().GetTop5WorkOrders())
            {
                while (dr.Read())
                {
                    workOrderCollection.Add(PopulateReader(dr));
                }
                dr.Close();
            }
            return workOrderCollection;
        }

        public WorkOrderCollection GetWorkOrdersByCustomerName(string name)
        {
            WorkOrderCollection workOrderCollection = new WorkOrderCollection();

            using (IDataReader dr = new WorkOrderDataAdapter().GetWorkOrdersByCustomerName(name))
            {
                while (dr.Read())
                {
                    workOrderCollection.Add(PopulateReader(dr));
                }
                dr.Close();
            }

            return workOrderCollection;
        }

        public WorkOrder GetWorkOrder(int workOrderId)
        {
            WorkOrder workOrder = new WorkOrder();

            using (IDataReader dr = new WorkOrderDataAdapter().GetWorkOrderById(workOrderId))
            {
                if (dr.Read())
                {
                    workOrder = PopulateReader(dr);
                }
                dr.Close();
            }
            return workOrder;
        }

        public int GetMaxId()
        {
            int maxId = 0;
            using (IDataReader dr = new WorkOrderDataAdapter().GetMaxId())
            {
                if (dr.Read())
                {
                    maxId = Convert.ToInt32(dr["id"]);
                }
                dr.Close();
            }
            return maxId;
        }

        private WorkOrder PopulateReader(IDataReader dr)
        {
            WorkOrder workOrder = new WorkOrder();
            if (dr["Id"] != DBNull.Value)
                workOrder.Id = Convert.ToInt32(dr["Id"]);
            workOrder.CustomerId = Convert.ToInt32(dr["CustomerId"]);
            workOrder.Description = dr["Description"].ToString();
            workOrder.MaterialId = dr["MaterialId"].ToString();
            workOrder.Quantity = Convert.ToInt32(dr["Quantity"]);
            workOrder.CastingWeight = Convert.ToInt32(dr["CastingWeight"]);
            workOrder.PatternCost = Convert.ToDecimal(dr["PatternCost"]);
            workOrder.MachiningCost = Convert.ToDecimal(dr["MachiningCost"]);
            workOrder.ModificationCost = Convert.ToDecimal(dr["ModificationCost"]);
            workOrder.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
            workOrder.Others = dr["Others"].ToString();
            workOrder.DeliveryDateTime = Convert.ToDateTime(dr["DeliveryDateTime"]);
            workOrder.Remarks = dr["Remarks"].ToString();

            return workOrder;
        }

        public bool Insert(WorkOrder workOrder)
        {
            return new WorkOrderDataAdapter().InsertWorkOrder(workOrder.Id,
                                    workOrder.CustomerId, workOrder.Description,
                                    workOrder.MaterialId, workOrder.Quantity,
                                    workOrder.CastingWeight, workOrder.PatternCost,
                                    workOrder.MachiningCost, workOrder.ModificationCost,
                                    workOrder.TotalCost, workOrder.Others, workOrder.DeliveryDateTime,
                                    workOrder.Remarks);
            
        }

        public bool Delete(int id)
        {
            return new WorkOrderDataAdapter().DeleteWorkOrder(id);
        }

        public bool Update(WorkOrder workOrder)
        {
            return new WorkOrderDataAdapter().UpdateWorkOrder(workOrder.Id,
                                    workOrder.CustomerId, workOrder.Description,
                                    workOrder.MaterialId, workOrder.Quantity,
                                    workOrder.CastingWeight, workOrder.PatternCost,
                                    workOrder.MachiningCost, workOrder.ModificationCost,
                                    workOrder.TotalCost, workOrder.Others, workOrder.DeliveryDateTime,
                                    workOrder.Remarks);
        }

        public bool IsWorkOrderExist(int id)
        {
            bool exist = false;

            using (IDataReader dr = new WorkOrderDataAdapter().GetWorkOrderById(id))
            {
                if (dr.Read())
                    exist = true;

                dr.Close();
            }

            return exist;
        }

        public WorkOrderCollection GetTop5Materials()
        {
            WorkOrderCollection workOrderCollection = new WorkOrderCollection();
            using (IDataReader dr = new WorkOrderDataAdapter().GetTop5Materials())
            {
                while (dr.Read())
                {
                    WorkOrder workOrder = new WorkOrder();
                    workOrder.MaterialId = dr["MaterialId"].ToString();
                    workOrderCollection.Add(workOrder);
                }
                dr.Close();
            }
            return workOrderCollection;
        }

        public WorkOrderCollection GetTop5Customers()
        {
            WorkOrderCollection workOrderCollection = new WorkOrderCollection();
            using (IDataReader dr = new WorkOrderDataAdapter().GetTop5Customers())
            {
                while (dr.Read())
                {
                    WorkOrder workOrder = new WorkOrder();
                    workOrder.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                    workOrderCollection.Add(workOrder);
                }
                dr.Close();
            }
            return workOrderCollection;
        }
    }
}
