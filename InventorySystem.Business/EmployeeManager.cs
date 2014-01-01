using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventorySystem.Data;
using System.Data;

namespace InventorySystem.Business
{
    public class EmployeeManager
    {
        private Employee PopulateReader(IDataReader dr)
        {
            Employee employee = new Employee();
            if (dr["Id"] != DBNull.Value)
                employee.Id = dr["Id"].ToString();
            employee.Name = dr["Name"].ToString();
            employee.Gender = dr["Gender"].ToString();
            employee.Position = dr["Position"].ToString();
            employee.Department = dr["Department"].ToString();
            employee.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
            employee.PhoneNo = dr["PhoneNo"].ToString();
            employee.Email = dr["Email"].ToString();
            employee.Address = dr["Address"].ToString();
            employee.PostalCode = dr["PostalCode"].ToString();
            employee.Country = dr["Country"].ToString();
            employee.Remarks = dr["Remarks"].ToString();
            return employee;
        }

        public EmployeeCollection GetEmployees()
        {
         EmployeeCollection employees = new EmployeeCollection();

         IDataReader dr = new EmployeeDataAdapter().GetEmployees();
            while (dr.Read())
            {
                employees.Add(PopulateReader(dr));
            }
         return employees;
        }
    }
}
