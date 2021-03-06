//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventorySystem.Orders.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public int Id { get; set; }
        public string MaterialCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public Nullable<decimal> PricePerUnit { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Remarks { get; set; }
    }
}
