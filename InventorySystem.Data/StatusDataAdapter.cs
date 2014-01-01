using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Data
{
    public class StatusDataAdapter : SqlServerConfig
    {
         private SqlServerConfig _conn;

         public StatusDataAdapter()
        {
            _conn = new SqlServerConfig();
        }
        public IDataReader GetStatusById(int Id)
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name
                                            FROM Status
                                        WHERE Id=@Id;");
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = Id;
            return _conn.ExecuteReader(query, parameters);
        }

        public IDataReader GetStatus()
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name
                                            FROM Status");
           
            return _conn.ExecuteReader(query);
        }
    }
}
