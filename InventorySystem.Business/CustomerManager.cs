using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InventorySystem.Data;

namespace InventorySystem.Business
{
    public class CustomerManager
    {
        public Customer GetCustomersById(int id)
        {
            Customer customer = new Customer();
            using (IDataReader dr = new CustomerDataAdapter().GetCustomerByCode(id))
            {
                if (dr.Read())
                {
                    customer = PopulateReader(dr);
                }
                dr.Close();
            }
            return customer;
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = new Customer();
            IDataReader dr = new CustomerDataAdapter().GetCustomerByEmail(email);
            if (dr.Read())
            {
                customer = PopulateReader(dr);
            }
            dr.Close();
            return customer;
        }

        public string GetMaxId()
        {
            string maxid = string.Empty;
            IDataReader dr = new CustomerDataAdapter().GetMaxId();

            while (dr.Read())
            {
                maxid = dr["id"].ToString();
            }
            dr.Close();
            return maxid;
        }

        public CustomerCollection GetCustomers()
        {
            CustomerCollection customers = new CustomerCollection();

            using(IDataReader dr = new CustomerDataAdapter().GetCustomers())
            {
            while (dr.Read())
            {
                customers.Add(PopulateReader(dr));
            }
            dr.Close();
            }
            return customers;
        }

        private Customer PopulateReader(IDataReader dr)
        {
            Customer customer = new Customer();
            customer.Id = Convert.ToInt32(dr["id"]);
            customer.Company = dr["Company"].ToString();
            customer.Name = dr["Name"].ToString();
            customer.PhoneNo = dr["PhoneNo"].ToString();
            customer.Email = dr["Email"].ToString();
            customer.Fax = dr["Fax"].ToString();
            customer.Address = dr["Address"].ToString();
            customer.Website = dr["Website"].ToString();
            customer.Remarks = dr["Remarks"].ToString();
            customer.PostCode = dr["PostCode"].ToString();
            customer.Country = dr["Country"].ToString();
            customer.Rating = Int32.Parse(dr["Rating"].ToString());

            return customer;
        }

        public bool Insert(Customer customer)
        {
            using (CustomerDataAdapter adapter = new CustomerDataAdapter())
            {
                return adapter.InsertCustomer(customer.Company,
                                                                customer.Name, customer.PhoneNo, customer.Email,
                                                                customer.Fax,
                                                                customer.Address, customer.Website, customer.Remarks,
                                                                customer.PostCode
                                                                , customer.Country, customer.Rating);    
            }
            
        }

        public bool Update(Customer customer)
        {
            using (CustomerDataAdapter adapter = new CustomerDataAdapter())
            {
                return adapter.UpdateCustomer(customer.Id, customer.Company,
                                                            customer.Name, customer.PhoneNo, customer.Email,
                                                            customer.Fax,
                                                            customer.Address, customer.Website, customer.Remarks,
                                                            customer.PostCode
                                                            , customer.Country, customer.Rating);
            }
            
        }

        public bool Delete(string id)
        {
            using (CustomerDataAdapter adapter = new CustomerDataAdapter())
            {
                return adapter.DeleteCustomer(id);    
            }
            
        }

        public bool IsCustomerExist(int id)
        {
            bool exist = false;

            using (IDataReader dr = new CustomerDataAdapter().GetCustomerByCode(id))
            {
                if (dr.Read())
                    exist = true;

                dr.Close();
            }

            return exist;
        }

    }
}
