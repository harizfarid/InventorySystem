using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }
        
        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Remarks { get; set; }
    }
}
