using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Entities;

namespace InventorySystem.Data
{
    public class MaterialDataAccess
    {
        public Material GetMaterialById(int id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Material.FirstOrDefault(P => P.Id == id);
            }
        }

        public Material GetMaterialByMaterialCode(string materialCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Material.FirstOrDefault(P => P.MaterialCode == materialCode);
            }
        }

        public List<Material> GetMaterials()
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                var q = from x in ctx.Material
                        select x;
                q = q.OrderBy(P => P.Name);
                return q.ToList();
            }
        }

        public List<Material> GetFilteredMaterials(string code, string name)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                IQueryable<Material> query = ctx.Material.AsQueryable();
                if (!String.IsNullOrEmpty(code))
                {
                    query = query.Where(P => P.MaterialCode.Contains(code));
                }
                if (!String.IsNullOrEmpty(name))
                {
                    query = query.Where(P => P.Name.Contains(name));
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
                    var item = ctx.Material.FirstOrDefault(P => P.Id == id);
                    ctx.Entry(item).State = System.Data.EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateAttachment(int? id,string attachment)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                if (id != null)
                {
                    var item = ctx.Material.FirstOrDefault(P => P.Id == id.Value);
                    item.Attachment = attachment;
                    ctx.SaveChanges();
                }
               
            }

        }
        public Material Insert(string materialCode, string name, string description
            , decimal? pricePerUnit, string attachment, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Material item = new Material();
                if (!String.IsNullOrEmpty(materialCode))
                {
                    item.MaterialCode = materialCode;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    item.Description = description;
                }
                if (pricePerUnit != null)
                {
                    item.PricePerUnit = pricePerUnit;
                }
                if (!String.IsNullOrEmpty(attachment))
                {
                    item.Attachment = attachment;
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
                ctx.Material.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public Material Update(int id, string materialCode, string name, string description
            , decimal? pricePerUnit, string attachment, DateTime? dateCreated
            , DateTime? dateModified, string createdBy, string modifiedBy)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Material item = ctx.Material.FirstOrDefault(P => P.Id == id);
                if (!String.IsNullOrEmpty(materialCode))
                {
                    item.MaterialCode = materialCode;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    item.Name = name;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    item.Description = description;
                }
                if (pricePerUnit != null)
                {
                    item.PricePerUnit = pricePerUnit;
                }
                if (!String.IsNullOrEmpty(attachment))
                {
                    item.Attachment = attachment;
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
                ctx.SaveChanges();
                return item;
            }
        }

    }
}
