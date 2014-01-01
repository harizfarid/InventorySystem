using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class MaterialModule
    {
        public Material GetMaterial(string id)
        {
            return new MaterialManager().GetMaterial(id);
        }
        
        public MaterialCollection GetMaterials()
        {
            return new MaterialManager().GetMaterials();
        }
    }
}
