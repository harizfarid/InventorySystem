using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventorySystem.Business
{
    public class EmployeeModule
    {
        public EmployeeCollection GetEmployees()
        {
            return new EmployeeManager().GetEmployees();
        }
    }
}
