using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace InventorySystem.Data
{
    public class EmployeeDataAdapter
    {
        private SqlServerConfig _conn;

        public EmployeeDataAdapter()
        {
            _conn = new SqlServerConfig();
        }
        public IDataReader GetEmployeeById(string id)
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name,
                                            Gender,
                                            Position,
                                            Department,
                                            DateOfBirth,
                                            PhoneNo,
                                            Email,
                                            Address,
                                            Remarks,
                                            PostalCode,
                                            Country
                                            FROM employee
                                        WHERE id=@id;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = id;
            return _conn.ExecuteReader(query, odbcParameters);
        }
        public IDataReader GetEmployees()
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name,
                                            Gender,
                                            Position,
                                            Department,
                                            DateOfBirth,
                                            PhoneNo,
                                            Email,
                                            Address,
                                            Remarks,
                                            PostalCode,
                                            Country
                                            FROM employee");

            return _conn.ExecuteReader(query);
        }
    }
}
