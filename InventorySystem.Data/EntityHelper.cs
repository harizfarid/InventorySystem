
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using Datakini.Framework;
using InventorySystem.Entities;
namespace InventorySystem.Data
{

	#region entity InventorySystemMaintenanceEntities
	#region unitOfWork InventorySystemMaintenanceEntities
	public class UnitOfWorkInventorySystemMaintenanceEntities :IDisposable,IUnitOfWork<InventorySystemMaintenanceEntities>
    {
        public readonly InventorySystemMaintenanceEntities _context;

        public UnitOfWorkInventorySystemMaintenanceEntities()
        {
            _context = new InventorySystemMaintenanceEntities();
        }

        public UnitOfWorkInventorySystemMaintenanceEntities(InventorySystemMaintenanceEntities context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

		public InventorySystemMaintenanceEntities Context
        {
            get { return _context; }
        }
    }
	#endregion
	
	#region Repository  Customer
	public interface ICustomerRepository : IRepository<Customer> { }
	
	public partial class CustomerRepository : ICustomerRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public CustomerRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Customer> FindAll
        {
            get { return _context.Customer; }
        }

		public IQueryable<Customer> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = _context.Customer;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Customer Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Customer.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Customer.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Customer item)
        {
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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
            var item = _context.Customer.Find(id);
            _context.Customer.Remove(item);
        }
		#endregion

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  Employee
	public interface IEmployeeRepository : IRepository<Employee> { }
	
	public partial class EmployeeRepository : IEmployeeRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public EmployeeRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Employee> FindAll
        {
            get { return _context.Employee; }
        }

		public IQueryable<Employee> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> query = _context.Employee;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Employee Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Employee.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Employee.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Employee item)
        {
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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
            var item = _context.Employee.Find(id);
            _context.Employee.Remove(item);
        }
		#endregion

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  Material
	public interface IMaterialRepository : IRepository<Material> { }
	
	public partial class MaterialRepository : IMaterialRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public MaterialRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
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
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  Pattern
	public interface IPatternRepository : IRepository<Pattern> { }
	
	public partial class PatternRepository : IPatternRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public PatternRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<Pattern> FindAll
        {
            get { return _context.Pattern; }
        }

		public IQueryable<Pattern> FindAllIncluding(params System.Linq.Expressions.Expression<Func<Pattern, object>>[] includeProperties)
        {
            IQueryable<Pattern> query = _context.Pattern;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public Pattern Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.Pattern.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.Pattern.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(Pattern item)
        {
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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
            var item = _context.Pattern.Find(id);
            _context.Pattern.Remove(item);
        }
		#endregion

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  Product
	public interface IProductRepository : IRepository<Product> { }
	
	public partial class ProductRepository : IProductRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public ProductRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
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
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  ProductGroup
	public interface IProductGroupRepository : IRepository<ProductGroup> { }
	
	public partial class ProductGroupRepository : IProductGroupRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public ProductGroupRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<ProductGroup> FindAll
        {
            get { return _context.ProductGroup; }
        }

		public IQueryable<ProductGroup> FindAllIncluding(params System.Linq.Expressions.Expression<Func<ProductGroup, object>>[] includeProperties)
        {
            IQueryable<ProductGroup> query = _context.ProductGroup;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public ProductGroup Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.ProductGroup.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.ProductGroup.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(ProductGroup item)
        {
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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
            var item = _context.ProductGroup.Find(id);
            _context.ProductGroup.Remove(item);
        }
		#endregion

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  Supplier
	public interface ISupplierRepository : IRepository<Supplier> { }
	
	public partial class SupplierRepository : ISupplierRepository
	{
		private InventorySystemMaintenanceEntities _context;
		public SupplierRepository(UnitOfWorkInventorySystemMaintenanceEntities uow)
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
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#endregion

	#region entity InventorySystemProcessEntities
	#region unitOfWork InventorySystemProcessEntities
	public class UnitOfWorkInventorySystemProcessEntities :IDisposable,IUnitOfWork<InventorySystemProcessEntities>
    {
        public readonly InventorySystemProcessEntities _context;

        public UnitOfWorkInventorySystemProcessEntities()
        {
            _context = new InventorySystemProcessEntities();
        }

        public UnitOfWorkInventorySystemProcessEntities(InventorySystemProcessEntities context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

		public InventorySystemProcessEntities Context
        {
            get { return _context; }
        }
    }
	#endregion
	
	#region Repository  SalesOrder
	public interface ISalesOrderRepository : IRepository<SalesOrder> { }
	
	public partial class SalesOrderRepository : ISalesOrderRepository
	{
		private InventorySystemProcessEntities _context;
		public SalesOrderRepository(UnitOfWorkInventorySystemProcessEntities uow)
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
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#region Repository  SalesOrderDetail
	public interface ISalesOrderDetailRepository : IRepository<SalesOrderDetail> { }
	
	public partial class SalesOrderDetailRepository : ISalesOrderDetailRepository
	{
		private InventorySystemProcessEntities _context;
		public SalesOrderDetailRepository(UnitOfWorkInventorySystemProcessEntities uow)
		{
			_context = uow._context;
		}

		#region Members
		public IQueryable<SalesOrderDetail> FindAll
        {
            get { return _context.SalesOrderDetail; }
        }

		public IQueryable<SalesOrderDetail> FindAllIncluding(params System.Linq.Expressions.Expression<Func<SalesOrderDetail, object>>[] includeProperties)
        {
            IQueryable<SalesOrderDetail> query = _context.SalesOrderDetail;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

		public SalesOrderDetail Find(object id)
        {
			Type idType = id.GetType();
			if(idType == typeof(string))
			{
			string stringId = Convert.ToString(id);
            return _context.SalesOrderDetail.Find(stringId);
			}
			else
			if(idType == typeof(int))
			{
			int intId = Convert.ToInt32(id);
            return _context.SalesOrderDetail.Find(intId);
			}
			return null;
        }

		public void InsertOrUpdate(SalesOrderDetail item)
        {
			Type idType = item.Id.GetType();
			if(idType == typeof(string))
			{
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                _context.Entry(item).State = System.Data.EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = System.Data.EntityState.Modified;
            }
			}
			else if(idType == typeof(int))
			{
			if (Convert.ToInt32(item.Id) == default(int))
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
            var item = _context.SalesOrderDetail.Find(id);
            _context.SalesOrderDetail.Remove(item);
        }
		#endregion

		#region IDisposable Members

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
	} 
	#endregion

	#endregion
}
