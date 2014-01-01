using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using System.Data;


namespace InventorySystem.Business
{
    public class MaterialManager
    {
        private Material PopulateReader(IDataReader dr)
        {
            Material material = new Material();
            if (dr["Id"] != DBNull.Value)
                material.Id = dr["Id"].ToString();
                material.Name = dr["Name"].ToString();
                material.Type = dr["Type"].ToString();
            return material;
        }
        public Material GetMaterial(string id)
        { 
            Material material = new Material();

            IDataReader dr = new MaterialDataAdapter().GetMaterialById(id);
            if (dr.Read())
            {
                material = PopulateReader(dr);
            }
            return material;
        }

        public MaterialCollection GetMaterials()
        {
            MaterialCollection materials = new MaterialCollection();

            IDataReader dr = new MaterialDataAdapter().GetMaterials();
            while (dr.Read())
            {
                materials.Add(PopulateReader(dr));
            }
            return materials;
        }
    }
}
