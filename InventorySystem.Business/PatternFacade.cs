using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using InventorySystem.Entities;

namespace InventorySystem.Business
{
    public class PatternFacade
    {
        private PatternDataAccess _da;

        public Pattern GetPatternById(int id)
        {
            _da = new PatternDataAccess();
            return _da.GetPatternById(id);
        }

        public Pattern GetPatternByPatternCode(string patternCode)
        {
            _da = new PatternDataAccess();
            return _da.GetPatternByPatternCode(patternCode);
        }

        public List<Pattern> GetPatterns()
        {
            _da = new PatternDataAccess();
            return _da.GetPatterns();
        }

        public List<Pattern> GetFilteredPatterns(string patternCode)
        {
            _da = new PatternDataAccess();
            return _da.GetFilteredPatterns(patternCode);
        }

        public void Delete(int? id)
        {
            _da = new PatternDataAccess();
            _da.Delete(id);

        }

        public Pattern Save(int? id, int? supplierId, string patternCode, string patternMaker,
    decimal? price, decimal? outerDiameter, decimal? innerDiameter, decimal? height,
    decimal? width, decimal? length, string modificationRemarks, DateTime? dateCreated,
    DateTime? dateModified, string createdBy, string modifiedBy, string remarks)
        {
            _da = new PatternDataAccess();
            if (id.HasValue)
            {
                return _da.Update(id.Value, supplierId, patternCode, patternMaker, price, outerDiameter
                                  , innerDiameter, height, width, length, modificationRemarks, dateCreated
                                  , dateModified, createdBy, modifiedBy, remarks);
            }

            return _da.Insert(supplierId, patternCode, patternMaker, price, outerDiameter
                              , innerDiameter, height, width, length, modificationRemarks, dateCreated
                              , dateModified, createdBy, modifiedBy, remarks);
        }

    }
}
