using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Entities;
using System.Data.Objects;

namespace InventorySystem.Data
{
    public class CustomerDataAccess
    {
        public List<Customer> GetCustomers()
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                var q = from x in ctx.Customer
                        select x;
                q = q.OrderBy(P => P.Name);
                return q.ToList();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Customer.FirstOrDefault(P => P.Id == id);
            }
        }

        public List<Customer> GetFilteredCustomers(string customerCode, string name, string email)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                IQueryable<Customer> query = ctx.Customer.AsQueryable();
                if (!String.IsNullOrEmpty(customerCode))
                {
                    query = query.Where(P => P.CustomerCode.Contains(customerCode));
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

        public Customer GetCustomerByCustomerCode(string customerCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Customer.FirstOrDefault(P => P.CustomerCode == customerCode);
            }
        }

        public Customer Insert(string customerCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Customer item = new Customer();
                if (!String.IsNullOrEmpty(customerCode))
                {
                    item.CustomerCode = customerCode;
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
                ctx.Customer.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public Customer Update(int id, string customerCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Customer item = ctx.Customer.FirstOrDefault(P => P.Id == id);
                if (!String.IsNullOrEmpty(customerCode))
                {
                    item.CustomerCode = customerCode;
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
                    var item = ctx.Customer.FirstOrDefault(P => P.Id == id);
                    ctx.Entry(item).State = System.Data.EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
        }

    }
}
