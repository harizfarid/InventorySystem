using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Entities;
using System.Data.Entity;
namespace InventorySystem.Data
{
    public class SupplierDataAccess
    {
        public List<Supplier> GetSuppliers()
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                var q = from x in ctx.Supplier
                        select x;
                q = q.OrderBy(P => P.Name);
                return q.ToList();
            }
        }

        public Supplier GetSupplierById(int id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Supplier.FirstOrDefault(P => P.Id == id);
            }
        }

        public Supplier GetSupplierBySupplierCode(string supplierCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Supplier.FirstOrDefault(P => P.SupplierCode == supplierCode);
            }
        }

        public List<Supplier> GetFilteredSuppliers(string supplierCode, string name, string email)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                IQueryable<Supplier> query = ctx.Supplier.AsQueryable();
                if (!String.IsNullOrEmpty(supplierCode))
                {
                    query = query.Where(P => P.SupplierCode.Contains(supplierCode));
                }
                if (!String.IsNullOrEmpty(name))
                {
                    query = query.Where(P => P.Name.Contains(name));
                }
                if (!String.IsNullOrEmpty(email))
                {
                    query = query.Where(P => P.Email.Contains(email));
                }
                return query.OrderBy(P => P.Name).ToList();
            }
        }

        public Supplier Insert(string supplierCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Supplier item = new Supplier();
                if (!String.IsNullOrEmpty(supplierCode))
                {
                    item.SupplierCode = supplierCode;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(company))
                {
                    item.Company = company;
                }
                if (!String.IsNullOrEmpty(phoneNo))
                {
                    item.PhoneNo = phoneNo;
                }
                if (!String.IsNullOrEmpty(fax))
                {
                    item.Fax = fax;
                }
                if (!String.IsNullOrEmpty(email))
                {
                    item.Email = email;
                }
                if (!String.IsNullOrEmpty(address))
                {
                    item.Address = address;
                }
                if (!String.IsNullOrEmpty(postcode))
                {
                    item.Postcode = postcode;
                }
                if (!String.IsNullOrEmpty(state))
                {
                    item.State = state;
                }
                if (!String.IsNullOrEmpty(country))
                {
                    item.Country = country;
                }
                if (!String.IsNullOrEmpty(website))
                {
                    item.Website = website;
                }
                if (dateCreated != null)
                {
                    item.DateCreated = dateCreated;
                }
                if (dateModified != null)
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
                ctx.Entry(item).State = System.Data.EntityState.Added;
                ctx.SaveChanges();
                return item;
            }
        }

        public Supplier Update(int id, string supplierCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Supplier item = ctx.Supplier.FirstOrDefault(P => P.Id == id);
                if (!String.IsNullOrEmpty(supplierCode))
                {
                    item.SupplierCode = supplierCode;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(company))
                {
                    item.Company = company;
                }
                if (!String.IsNullOrEmpty(phoneNo))
                {
                    item.PhoneNo = phoneNo;
                }
                if (!String.IsNullOrEmpty(fax))
                {
                    item.Fax = fax;
                }
                if (!String.IsNullOrEmpty(email))
                {
                    item.Email = email;
                }
                if (!String.IsNullOrEmpty(address))
                {
                    item.Address = address;
                }
                if (!String.IsNullOrEmpty(postcode))
                {
                    item.Postcode = postcode;
                }
                if (!String.IsNullOrEmpty(state))
                {
                    item.State = state;
                }
                if (!String.IsNullOrEmpty(country))
                {
                    item.Country = country;
                }
                if (!String.IsNullOrEmpty(website))
                {
                    item.Website = website;
                }
                if (dateCreated != null)
                {
                    item.DateCreated = dateCreated;
                }
                if (dateModified != null)
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

        public void Delete(int? id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                if (id != null)
                {
                    var item = ctx.Supplier.FirstOrDefault(P => P.Id == id);
                    ctx.Entry(item).State = System.Data.EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
