using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Data
{
    public class MembershipDataAdapter : SqlServerConfig
    {
        private SqlServerConfig _conn;

        public MembershipDataAdapter()
        {
            _conn = new SqlServerConfig();
        }

        public IDataReader GetMembershipById(int id)
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Username,
                                            Password,
                                            Authorization,
                                            EmployeeId
                                            FROM membership
                                        WHERE id=@id;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            odbcParameters[0].Value = id;
            return _conn.ExecuteReader(query, odbcParameters);
        }

        public IDataReader GetMembershipByUsername(string userName)
        {
            string query = string.Format(@"SELECT
                                           *
                                            FROM Membership
                                        WHERE Username=@Username;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@Username", SqlDbType.VarChar);
            odbcParameters[0].Value = userName;
            return _conn.ExecuteReader(query, odbcParameters);
        }

        public bool InsertMembership(string username, string password, int authorization,
                                     string employeeId)
        {
            string query =
                @"INSERT INTO membership
                    (Username,
                     Password,
                     Authorization,
                     EmployeeId)
                    VALUES
                    (
                    @Username,
                    @Password,
                    @Authorization,
                    @EmployeeId
                    )";
             SqlParameter[] odbcParameters = new SqlParameter[4];
             odbcParameters[0] = new SqlParameter("@Username", SqlDbType.VarChar);
             odbcParameters[0].Value = Convert.ToString(username);
             odbcParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
             odbcParameters[1].Value = Convert.ToString(password);
             odbcParameters[2] = new SqlParameter("@Authorization", SqlDbType.Int);
             odbcParameters[2].Value = Convert.ToInt32(authorization);
             odbcParameters[3] = new SqlParameter("@EmployeeId", SqlDbType.VarChar);
             odbcParameters[3].Value = Convert.ToString(employeeId);

             return _conn.ExecuteNonQuery(query, odbcParameters);
        }
    }
}
