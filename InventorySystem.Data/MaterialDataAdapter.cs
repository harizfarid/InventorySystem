using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Data
{
    public class MaterialDataAdapter
    {
        private SqlServerConfig _conn;

        public MaterialDataAdapter()
        {
            _conn = new SqlServerConfig();
        }

        public IDataReader GetMaterialById(string id)
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name,
                                            Type
                                            FROM material
                                        WHERE id=@id;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = id;
            return _conn.ExecuteReader(query, odbcParameters);
        }
        public IDataReader GetMaterials()
        {
            string query = string.Format(@"SELECT
                                            Id,
                                            Name,
                                            Type
                                            FROM material"
                                                    );
            return _conn.ExecuteReader(query);
        }
    }
}
