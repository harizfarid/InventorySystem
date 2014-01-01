using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using InventorySystem.Entities;

namespace InventorySystem.Business
{
    public class MaterialFacade
    {
        private MaterialDataAccess _da;

        public Entities.Material GetMaterialById(int id)
        {
            _da = new MaterialDataAccess();
            return _da.GetMaterialById(id);
        }

        public Entities.Material GetMaterialByMaterialCode(string materialCode)
        {
            _da = new MaterialDataAccess();
            return _da.GetMaterialByMaterialCode(materialCode);
        }

        public List<Entities.Material> GetMaterials()
        {
            _da = new MaterialDataAccess();
            return _da.GetMaterials();
        }

        public List<Entities.Material> GetFilteredMaterials(string code, string name)
        {
            _da = new MaterialDataAccess();
           return  _da.GetFilteredMaterials(code, name);
        }

        public Entities.Material Save(int? id, string materialCode, string name, string description
            , decimal? pricePerUnit, string attachment, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy)
        {
            _da = new MaterialDataAccess();
            if (id.HasValue)
            {
                return _da.Update(id.Value, materialCode, name, description, pricePerUnit, attachment
                               , dateCreated, dateModified, createdBy, modifiedBy);
            }
            return _da.Insert(materialCode, name, description, pricePerUnit, attachment
                              , dateCreated, dateModified, createdBy, modifiedBy);
        }

        public void UpdateAttachment(int? id,string attachment)
        {
            _da = new MaterialDataAccess();
            _da.UpdateAttachment(id,attachment);
        }

        public void Delete(int? id)
        {
            _da = new MaterialDataAccess();
            _da.Delete(id);
        }
    }
}
