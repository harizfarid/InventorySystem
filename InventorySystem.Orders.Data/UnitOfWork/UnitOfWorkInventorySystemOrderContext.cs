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

	#region unitOfWork InventorySystemOrderContext
	public class UnitOfWorkInventorySystemOrderContext :IDisposable,IUnitOfWork<InventorySystemOrderContext>
	{
		public readonly InventorySystemOrderContext _context;

		public UnitOfWorkInventorySystemOrderContext()
		{
			_context = new InventorySystemOrderContext();
		}

		public UnitOfWorkInventorySystemOrderContext(InventorySystemOrderContext context)
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

		public InventorySystemOrderContext Context
		{
			get { return _context; }
		}
	}
	#endregion
}

