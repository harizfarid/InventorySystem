using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using InventorySystem.Entities;

namespace InventorySystem.Business
{
    public class CustomerFacade
    {
        private CustomerDataAccess _da;

        public List<Entities.Customer> GetFilteredCustomer(string customerCode, string name, string email)
        {
            _da = new CustomerDataAccess();
            return _da.GetFilteredCustomers(customerCode, name, email);
        }

        public Entities.Customer GetCustomerById(int id)
        {
            _da = new CustomerDataAccess();
            return _da.GetCustomerById(id);
        }

        public Entities.Customer GetCustomerByCustomerCode(string customerCode)
        {
            _da = new CustomerDataAccess();
            return _da.GetCustomerByCustomerCode(customerCode);
        }

        public List<Entities.Customer> GetCustomers()
        {
            _da = new CustomerDataAccess();
            return _da.GetCustomers();
        }

        public Entities.Customer Save(int? id, string customerCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            _da = new CustomerDataAccess();
            if (id.HasValue)
            {
                return _da.Update(id.Value, customerCode, name, company, phoneNo, fax, email, address
                                  , postcode, state, country, website, dateCreated, dateModified, createdBy
                                  , modifiedBy, remarks);
            }
            return _da.Insert(customerCode, name, company, phoneNo, fax, email, address
                              , postcode, state, country, website, dateCreated, dateModified, createdBy
                              , modifiedBy, remarks);
        }

        public void Delete(int? id)
        {
            _da = new CustomerDataAccess();
            _da.Delete(id);
        }
    }
}
