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
	#region Repository  Material
	public interface IMaterialRepository : IRepository<Material> { }
	
	public partial class MaterialRepository : IMaterialRepository
	{
		private InventorySystemOrderContext _context;
		public MaterialRepository(UnitOfWorkInventorySystemOrderContext uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Material> FindAll
        {
            get { return _context.Material; }
        }

		public IQueryable<Material> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Material, object>>[] includeProperties)
        {
            IQueryable<Material> query = _context.Material;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Material Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Material.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Material.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Material item)
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
            var item = _context.Material.Find(id);
            _context.Material.Remove(item);
        }
		#endregion
	} 
	#endregion
}
