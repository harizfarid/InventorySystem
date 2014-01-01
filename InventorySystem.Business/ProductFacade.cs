using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using InventorySystem.Entities;

namespace InventorySystem.Business
{
    public class ProductFacade
    {
        private ProductDataAccess _da;
        public List<InventorySystem.Entities.Product> GetProducts()
        {
            _da = new ProductDataAccess();
            return _da.GetProducts();
        }

        public Entities.Product GetProductById(int id)
        {
            _da = new ProductDataAccess();
            return _da.GetProductById(id);
        }

        public Entities.Product GetProductByProductCode(string productCode)
        {
            _da = new ProductDataAccess();
            return _da.GetProductByProductCode(productCode);
        }

        public Entities.Product Save(int? id, string productCode, int? productGroupId, int? customerId,
            int? supplierId, string name, string description, decimal? weight, string image,
            decimal? outerDiameter, decimal? innerDiameter, decimal? height, decimal? width,
            decimal? length, DateTime? dateCreated, DateTime? dateModified, string createdBy,
            string modifiedBy, string remarks)
        {
            _da = new ProductDataAccess();
            if (id.HasValue)
                return _da.Update(id.Value, productCode, productGroupId, customerId, supplierId, name,
                          description, weight, image, outerDiameter, innerDiameter, height, width,
                          length, dateCreated, dateModified, createdBy, modifiedBy, remarks);

            return _da.Insert(productCode, productGroupId, customerId, supplierId, name,
                        description, weight, image, outerDiameter, innerDiameter, height, width,
                        length, DateTime.Now, dateModified, createdBy, modifiedBy, remarks);
        }

        public List<Entities.Product> GetFilteredProducts(string productCode, string productName, int productGroup, int customer, int supplier)
        {
            _da = new ProductDataAccess();
            return _da.GetFilteredProducts(productCode, productName, productGroup, customer, supplier);
        }

        public void Delete(int? id)
        {
            _da = new ProductDataAccess();
            _da.Delete(id);
        }
    }
}

