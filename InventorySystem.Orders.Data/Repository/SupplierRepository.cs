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
	#region Repository  Supplier
	public interface ISupplierRepository : IRepository<Supplier> { }
	
	public partial class SupplierRepository : ISupplierRepository
	{
		private InventorySystemOrderContext _context;
		public SupplierRepository(UnitOfWorkInventorySystemOrderContext uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Supplier> FindAll
        {
            get { return _context.Supplier; }
        }

		public IQueryable<Supplier> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Supplier, object>>[] includeProperties)
        {
            IQueryable<Supplier> query = _context.Supplier;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Supplier Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Supplier.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Supplier.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Supplier item)
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
            var item = _context.Supplier.Find(id);
            _context.Supplier.Remove(item);
        }
		#endregion
	} 
	#endregion
}
