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
	#region Repository  Product
	public interface IProductRepository : IRepository<Product> { }
	
	public partial class ProductRepository : IProductRepository
	{
		private InventorySystemOrderContext _context;
		public ProductRepository(UnitOfWorkInventorySystemOrderContext uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Product> FindAll
        {
            get { return _context.Product; }
        }

		public IQueryable<Product> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = _context.Product;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Product Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Product.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Product.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Product item)
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
            var item = _context.Product.Find(id);
            _context.Product.Remove(item);
        }
		#endregion
	} 
	#endregion
}
