using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace InventorySystem.Data
{
    public class AuthorizationDataAdapter : SqlServerConfig
    {
        private SqlServerConfig _conn;

        public AuthorizationDataAdapter()
        {
            _conn = new SqlServerConfig();
        }
        public IDataReader GetAuthorizationById(int Id)
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Level
                                            FROM authorization
                                        WHERE Id=@Id;");
            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            odbcParameters[0].Value = Id;
            return _conn.ExecuteReader(query, odbcParameters);
        }

        public IDataReader GetAuthorizations()
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Level
                                            FROM authorization");

            return _conn.ExecuteReader(query);
        }

    }
}
