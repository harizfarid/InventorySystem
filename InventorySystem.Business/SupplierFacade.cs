using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using InventorySystem.Entities;

namespace InventorySystem.Business
{
    public class SupplierFacade
    {
        private SupplierDataAccess _da;

        public Entities.Supplier GetSupplierById(int id)
        {
            _da = new SupplierDataAccess();
            return _da.GetSupplierById(id);
        }

        public Entities.Supplier GetSupplierBySupplierCode(string supplierCode)
        {
            _da = new SupplierDataAccess();
            return _da.GetSupplierBySupplierCode(supplierCode);
        }

        public List<Entities.Supplier> GetSuppliers()
        {
            _da = new SupplierDataAccess();
            return _da.GetSuppliers();
        }

        public List<Entities.Supplier> GetFilteredSuppliers(string supplierCode, string name, string email)
        {
            _da = new SupplierDataAccess();
            return _da.GetFilteredSuppliers(supplierCode, name, email);
        }

        public Entities.Supplier Save(int? id, string supplierCode, string name, string company
            , string phoneNo, string fax, string email, string address, string postcode
            , string state, string country, string website, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            _da = new SupplierDataAccess();
            if (id.HasValue)
            {
                return _da.Update(id.Value, supplierCode, name, company, phoneNo, fax, email, address
                                  , postcode, state, country, website, dateCreated, dateModified, createdBy
                                  , modifiedBy, remarks);
            }
            return _da.Insert(supplierCode, name, company, phoneNo, fax, email, address
                              , postcode, state, country, website, dateCreated, dateModified, createdBy
                              , modifiedBy, remarks);
        }

        public void Delete(int? id)
        {
            _da = new SupplierDataAccess();
            _da.Delete(id);
        }
    }
}
