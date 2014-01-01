using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;      
using System.Data.Entity;
using System.Reflection;
using Datakini.Framework;
using InventorySystem.Orders.Entities;
namespace InventorySystem.Orders.Data
{
	#region Repository  SalesOrder
	public interface ISalesOrderRepository : IRepository<SalesOrder> { }
	
	public partial class SalesOrderRepository : ISalesOrderRepository
	{
		private InventorySystemOrderContext _context;
		public SalesOrderRepository(UnitOfWorkInventorySystemOrderContext uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<SalesOrder> FindAll
        {
            get { return _context.SalesOrder; }
        }

		public IQueryable<SalesOrder> FindAllIncluding(params System.Linq.Expressions.Expression<Func<SalesOrder, object>>[] includeProperties)
        {
            IQueryable<SalesOrder> query = _context.SalesOrder;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public SalesOrder Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.SalesOrder.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.SalesOrder.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(SalesOrder item)
        { 
			List<PropertyInfo> properties = new List<PropertyInfo>();
		    foreach (var property in item.GetType().GetProperties())
		    {
		        if (!property.GetMethod.IsVirtual)
		        {
		            properties.Add(property);
		        }
		    }
			string id = properties[0].Name;
            //Type idType = item.GetType().GetProperties()[0].GetType();
			Type idType = _context.Entry(item).Property(id).CurrentValue.GetType();
            object currentValue = _context.Entry(item).Property(id).CurrentValue;
            if (idType == typeof(string))
            {
                if (String.IsNullOrEmpty(currentValue.ToString()))
                {
                    _context.Entry(item).State = System.Data.EntityState.Added;
                }
                else
                {
                    _context.Entry(item).State = System.Data.EntityState.Modified;
                }
            }
            else if (idType == typeof(int))
            {
                if (Convert.ToInt32(currentValue) == default(int))
                {
                    _context.Entry(item).State = System.Data.EntityState.Added;
                }
                else
                {
                    _context.Entry(item).State = System.Data.EntityState.Modified;
                }
            }
			 else if(idType == typeof(Guid))
            {
                if (!String.IsNullOrEmpty(currentValue.ToString()))
                {
                    _context.Entry(item).State = System.Data.EntityState.Added;
                }
                else
                {
                    _context.Entry(item).State = System.Data.EntityState.Modified;
                }
            }
        }

		public void Delete(int id)
        {
            var item = _context.SalesOrder.Find(id);
            _context.SalesOrder.Remove(item);
        }
		#endregion
	} 
	#endregion
}