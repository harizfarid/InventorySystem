using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class Customer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public string Remarks { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public int Rating { get; set; }


        public void Save()
        {
            int intId = 0;
            CustomerManager customerManager = new CustomerManager();
            if (!customerManager.IsCustomerExist(Id))
            {
                
                customerManager.Insert(this);
            }
            else
                customerManager.Update(this);

        }

        public int GetIntId(string customerId)
        {

            int intId = Convert.ToInt32(customerId.Substring(3, 5));

            return intId;
        }

    }


}
