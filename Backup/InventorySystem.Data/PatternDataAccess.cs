using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Entities;

namespace InventorySystem.Data
{
    public class PatternDataAccess
    {
        public List<Pattern> GetPatterns()
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                var q = from x in ctx.Pattern
                        select x;
                q = q.OrderBy(P => P.PatternCode);
                return q.ToList();
            }
        }

        public Pattern GetPatternById(int id)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Pattern.FirstOrDefault(P => P.Id == id);
            }
        }

        public Pattern GetPatternByPatternCode(string patternCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                return ctx.Pattern.FirstOrDefault(P => P.PatternCode == patternCode);
            }
        }

        public List<Pattern> GetFilteredPatterns(string patternCode)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                IQueryable<Pattern> query = ctx.Pattern.AsQueryable();
                if (!String.IsNullOrEmpty(patternCode))
                {
                    query = query.Where(P => P.PatternCode.Contains(patternCode));
                }
                return query.OrderBy(P => P.Id).ToList();
            }
        }

        public Pattern Insert(int? supplierId, string patternCode, string patternMaker,
            decimal? price, decimal? outerDiameter, decimal? innerDiameter, decimal? height,
            decimal? width, decimal? length, string modificationRemarks, DateTime? dateCreated,
            DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Pattern item = new Pattern();
                if (supplierId != null)
                {
                    item.SupplierId = supplierId;
                }
                if (!String.IsNullOrEmpty(patternCode))
                {
                    item.PatternCode = patternCode;
                }
                if (!String.IsNullOrEmpty(patternMaker))
                {
                    item.PatternMaker = patternMaker;
                }
                if (outerDiameter != null)
                {
                    item.OuterDiameter = outerDiameter;
                }
                if (innerDiameter != null)
                {
                    item.InnerDiameter = innerDiameter;
                }
                if (height != null)
                {
                    item.Height = height;
                }
                if (width != null)
                {
                    item.Width = width;
                }
                if (length != null)
                {
                    item.Length = length;
                }
                if (!String.IsNullOrEmpty(modificationRemarks))
                {
                    item.ModificationRemarks = modificationRemarks;
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
                ctx.AddToPattern(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public Pattern Update(int id, int? supplierId, string patternCode, string patternMaker,
    decimal? price, decimal? outerDiameter, decimal? innerDiameter, decimal? height,
    decimal? width, decimal? length, string modificationRemarks, DateTime? dateCreated,
    DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            using (var ctx = new InventorySystemMaintenanceEntities())
            {
                Pattern item = ctx.Pattern.FirstOrDefault(P => P.Id == id);

                if (supplierId != null)
                {
                    item.SupplierId = supplierId;
                }
                if (!String.IsNullOrEmpty(patternCode))
                {
                    item.PatternCode = patternCode;
                }
                if (!String.IsNullOrEmpty(patternMaker))
                {
                    item.PatternMaker = patternMaker;
                }
                if (outerDiameter != null)
                {
                    item.OuterDiameter = outerDiameter;
                }
                if (innerDiameter != null)
                {
                    item.InnerDiameter = innerDiameter;
                }
                if (height != null)
                {
                    item.Height = height;
                }
                if (width != null)
                {
                    item.Width = width;
                }
                if (length != null)
                {
                    item.Length = length;
                }
                if (!String.IsNullOrEmpty(modificationRemarks))
                {
                    item.ModificationRemarks = modificationRemarks;
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
                    var item = ctx.Pattern.FirstOrDefault(P => P.Id == id);
                    ctx.DeleteObject(item);
                    ctx.SaveChanges();
                }
            }
        }

    }
}
