using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class CustomerModule
    {

        public CustomerCollection GetCustomers()
        {
            return new CustomerManager().GetCustomers();
        }

        public List<LookupEntity> GetCustomersLookUp()
        {
            CustomerCollection customers = this.GetCustomers();
            List<LookupEntity> lookUps = new List<LookupEntity>();
            foreach (Customer customer in customers)
            {
                lookUps.Add(new LookupEntity(customer.Id.ToString(),customer.Name));
            }
            lookUps.OrderBy(P => P.Name);
            return lookUps;
        }

        public Customer GetCustomerById(int id)
        {
            return new CustomerManager().GetCustomersById(id);
        }

        public bool Delete(string id)
        {
            return new CustomerManager().Delete(id);
        }

        public void Save(Customer customer)
        {
            customer.Save();
        }
    }
}
