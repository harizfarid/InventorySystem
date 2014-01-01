using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Entities;
namespace InventorySystem.Business
{
    public class SalesOrderFacade
    {
        UnitOfWorkInventorySystemProcessEntities _uowProcess;
        public IQueryable<SalesOrder> GetSalesOrderWithDetails()
        {
            List<SalesOrder> salesOrder = new List<SalesOrder>();
            using (_uowProcess = new UnitOfWorkInventorySystemProcessEntities())
            {
                SalesOrderRepository repo = new SalesOrderRepository(_uowProcess);
                salesOrder = repo.FindAllIncluding(c => c.SalesOrderDetails).ToList();   
            }

            return salesOrder.AsQueryable();
        }

        public IQueryable<SalesOrder> GetSalesOrder()
        {
            List<SalesOrder> salesOrder = new List<SalesOrder>();
            using (_uowProcess = new UnitOfWorkInventorySystemProcessEntities())
            {
                SalesOrderRepository repo = new SalesOrderRepository(_uowProcess);
                salesOrder = repo.FindAll.ToList();
            }
            return salesOrder.AsQueryable();
        }

        public SalesOrder GetSalesOrderById(int id)
        {
            SalesOrder salesOrder = new SalesOrder();
            using (_uowProcess = new UnitOfWorkInventorySystemProcessEntities())
            {
                SalesOrderRepository repo = new SalesOrderRepository(_uowProcess);
                salesOrder = repo.Find(id);
            }
            
            return salesOrder;
        }
    }
}
