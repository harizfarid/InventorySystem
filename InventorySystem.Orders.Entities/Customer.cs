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
    
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Remarks { get; set; }
    }
}
