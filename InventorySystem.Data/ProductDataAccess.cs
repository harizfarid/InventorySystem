using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Entities;

namespace InventorySystem.Data
{
    public class ProductDataAccess : IDisposable
    {
        private InventorySystemMaintenanceEntities _context;

        public List<Product> GetProducts()
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                var q = from x in ctx.Product
                        select x;
                q = q.OrderBy(P => P.Name);
                return q.ToList();
            }

        }

        public Product GetProductById(int id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Product.FirstOrDefault(P => P.Id == id);
            }
        }

        public Product GetProductByProductCode(string productCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                if (!String.IsNullOrEmpty(productCode))
                {
                    return ctx.Product.FirstOrDefault(P => P.ProductCode == productCode);
                }
                return null;
            }
        }

        public Product Insert(string productCode, int? productGroupId, int? customerId,
            int? supplierId, string name, string description, decimal? weight, string image,
            decimal? outerDiameter, decimal? innerDiameter, decimal? height, decimal? width,
            decimal? length, DateTime? dateCreated, DateTime? dateModified, string createdBy,
            string modifiedBy, string remarks)
        {

            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Product item = new Product();
                if (!String.IsNullOrEmpty(productCode))
                {
                    item.ProductCode = productCode;
                }
                if (CheckNull(productGroupId))
                {
                    item.ProductGroupId = productGroupId;
                }
                if (CheckNull(customerId))
                {
                    item.CustomerId = customerId;
                }
                if (CheckNull(supplierId))
                {
                    item.SupplierId = supplierId;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    item.Description = description;
                }
                if (CheckNull(weight))
                {
                    item.Weight = weight;
                }
                if (!String.IsNullOrEmpty(image))
                {
                    item.Image = image;
                }
                if (CheckNull(outerDiameter))
                {
                    item.OuterDiameter = outerDiameter;
                }
                if (CheckNull(innerDiameter))
                {
                    item.InnerDiameter = innerDiameter;
                }
                if (CheckNull(height))
                {
                    item.Height = height;
                }
                if (CheckNull(width))
                {
                    item.Width = width;
                }
                if (CheckNull(length))
                {
                    item.Length = length;
                }
                if (CheckNull(dateCreated))
                {
                    item.DateCreated = dateCreated;
                }
                if (CheckNull(dateModified))
                {
                    item.DateModified = dateModified;
                }
                if (!String.IsNullOrEmpty(createdBy))
                {
                    item.CreatedBy = createdBy;
                }
                if (!String.IsNullOrEmpty(modifiedBy))
                {
                    item.ModifiedBy = modifiedBy;
                }
                if (!String.IsNullOrEmpty(remarks))
                {
                    item.Remarks = remarks;
                }
                ctx.Product.Add(item);
                ctx.SaveChanges();
                return item;
            }

        }

        public Product Update(int id, string productCode, int? productGroupId, int? customerId,
            int? supplierId, string name, string description, decimal? weight, string image,
            decimal? outerDiameter, decimal? innerDiameter, decimal? height, decimal? width,
            decimal? length, DateTime? dateCreated, DateTime? dateModified, string createdBy,
            string modifiedBy, string remarks)
        {

            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Product item = ctx.Product.FirstOrDefault(P => P.Id == id);
                if (!String.IsNullOrEmpty(productCode))
                {
                    item.ProductCode = productCode;
                }
                if (CheckNull(productGroupId))
                {
                    item.ProductGroupId = productGroupId;
                }
                if (CheckNull(customerId))
                {
                    item.CustomerId = customerId;
                }
                if (CheckNull(supplierId))
                {
                    item.SupplierId = supplierId;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    item.Description = description;
                }
                if (CheckNull(weight))
                {
                    item.Weight = weight;
                }
                if (!String.IsNullOrEmpty(image))
                {
                    item.Image = image;
                }
                if (CheckNull(outerDiameter))
                {
                    item.OuterDiameter = outerDiameter;
                }
                if (CheckNull(innerDiameter))
                {
                    item.InnerDiameter = innerDiameter;
                }
                if (CheckNull(height))
                {
                    item.Height = height;
                }
                if (CheckNull(width))
                {
                    item.Width = width;
                }
                if (CheckNull(length))
                {
                    item.Length = length;
                }
                if (CheckNull(dateCreated))
                {
                    item.DateCreated = dateCreated;
                }
                if (CheckNull(dateModified))
                {
                    item.DateModified = dateModified;
                }
                if (!String.IsNullOrEmpty(createdBy))
                {
                    item.CreatedBy = createdBy;
                }
                if (!String.IsNullOrEmpty(modifiedBy))
                {
                    item.ModifiedBy = modifiedBy;
                }
                if (!String.IsNullOrEmpty(remarks))
                {
                    item.Remarks = remarks;
                }
                ctx.SaveChanges();
                return item;
            }

        }


        private bool CheckNull(object value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        public List<Product> GetFilteredProducts(string productCode, string productName, int productGroup, int customer, int supplier)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                IQueryable<Product> query = ctx.Product.AsQueryable();
                if (!String.IsNullOrEmpty(productCode))
                {
                    query = query.Where(P => P.ProductCode.Contains(productCode));
                }
                if (!String.IsNullOrEmpty(productName))
                {
                    query = query.Where(P => P.Name.Contains(productName));
                }
                if (productGroup!= 0)
                {
                    query = query.Where(P => P.ProductGroupId == productGroup);
                }
                if (customer != 0)
                {
                    query = query.Where(P => P.CustomerId == customer);
                }
                if (supplier != 0)
                {
                    query = query.Where(P => P.SupplierId == 0);
                }
                foreach (Product product in query)
                {
                    if (product.CustomerId.HasValue)
                    {
                        //product.LoadCustomer(product.CustomerId.Value);
                    }

                    if (product.SupplierId.HasValue)
                    {
                        //product.LoadSupplier(product.SupplierId.Value);
                    }

                    if (product.ProductGroupId.HasValue)
                    {
                        //product.LoadProductGroupName(product.ProductGroupId.Value);
                    }
                }
                return query.OrderBy(P => P.Name).ToList();
            }
        }

        public void Delete(int? id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                if (id != null)
                {
                    var item = ctx.Product.FirstOrDefault(P => P.Id == id);
                    ctx.Entry(item).State = System.Data.EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
        }


        #region IDisposable Members
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true); //i am calling you from Dispose, it's safe
            GC.SuppressFinalize(this); //Hey, GC: don't bother calling finalize later
        }

        #endregion
    }
}
