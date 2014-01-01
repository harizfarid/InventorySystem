using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem.Data
{
    public class WorkOrderDataAdapter
    {
        //private MySqlConfig _conn;
        private SqlServerConfig _conn;

        public WorkOrderDataAdapter()
        {
            _conn = new SqlServerConfig();
        }

        public IDataReader GetWorkOrderById(int id)
        {
            string query = string.Format(@"SELECT
                                            id,
                                            CustomerId,
                                            Description,
                                            MaterialId,
                                            Quantity,
                                            CastingWeight,
                                            PatternCost,
                                            MachiningCost,
                                            ModificationCost,
                                            TotalCost,
                                            Others,
                                            DeliveryDateTime,
                                            Remarks
                                            FROM workorder
                                        WHERE id=@id;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            odbcParameters[0].Value = id;
            return _conn.ExecuteReader(query, odbcParameters);
            
        }


        public IDataReader GetWorkOrders()
        {
            string query = string.Format(@"SELECT
                                            id,
                                            CustomerId,
                                            Description,
                                            MaterialId,
                                            Quantity,
                                            CastingWeight,
                                            PatternCost,
                                            MachiningCost,
                                            ModificationCost,
                                            TotalCost,
                                            Others,
                                            DeliveryDateTime,
                                            Remarks
                                            FROM workorder");

            return _conn.ExecuteReader(query);
        }

        public IDataReader GetTop5WorkOrders()
        {
            string query = string.Format(@"SELECT TOP 5
                                            id,
                                            CustomerId,
                                            Description,
                                            MaterialId,
                                            Quantity,
                                            CastingWeight,
                                            PatternCost,
                                            MachiningCost,
                                            ModificationCost,
                                            TotalCost,
                                            Others,
                                            DeliveryDateTime,
                                            Remarks
                                            FROM workorder ORDER BY id desc ");

            return _conn.ExecuteReader(query);
        }

        public IDataReader GetWorkOrdersByCustomerName(string name)
        {
            string query = string.Format(@"SELECT
                                            wo.id,
                                            CustomerId,
                                            Description,
                                            MaterialId,
                                            Quantity,
                                            CastingWeight,
                                            PatternCost,
                                            MachiningCost,
                                            ModificationCost,
                                            TotalCost,
                                            Others,
                                            DeliveryDateTime,
                                            wo.Remarks
                                            FROM workorder wo
        INNER JOIN Customer c ON c.Id = wo.CustomerId 
        WHERE c.Name LIKE '%"+name+"%'  ");
            return _conn.ExecuteReader(query);
        }

        public IDataReader GetMaxId()
        {
            string query = string.Format(@"SELECT
                                            MAX(id) AS id
                                            FROM workorder");

            return _conn.ExecuteReader(query);
        }

        public bool InsertWorkOrder(int id, int customerId, string description, string materialId,
                                    int quantity, int castingWeight, decimal patternCost,
                                    decimal machiningCost, decimal modificationCost,
                                    decimal totalCost, string others, DateTime DeliveryDateTime,
                                    string remarks)
        {
            string query =
                @"INSERT INTO workorder
                    (id,
                    CustomerId,
                    Description,
                    MaterialId,
                    Quantity,
                    CastingWeight,
                    PatternCost,
                    MachiningCost,
                    ModificationCost,
                    TotalCost,
                    Others,
                    DeliveryDateTime,
                    Remarks)
                    VALUES
                    (
                    @id,
                    @CustomerId,
                    @Description,
                    @MaterialId,
                    @Quantity,
                    @CastingWeight,
                    @PatternCost,
                    @MachiningCost,
                    @ModificationCost,
                    @TotalCost,
                    @Others,
                    @DeliveryDateTime,
                    @Remarks
                    )";
            SqlParameter[] odbcParameters = new SqlParameter[13];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = Convert.ToString(id);
            odbcParameters[1] = new SqlParameter("@CustomerId", SqlDbType.VarChar);
            odbcParameters[1].Value = Convert.ToString(customerId);
            odbcParameters[2] = new SqlParameter("@Description", SqlDbType.VarChar);
            odbcParameters[2].Value = Convert.ToString(description);
            odbcParameters[3] = new SqlParameter("@MaterialId", SqlDbType.VarChar);
            odbcParameters[3].Value = Convert.ToString(materialId);
            odbcParameters[4] = new SqlParameter("@Quantity", SqlDbType.Int);
            odbcParameters[4].Value = Convert.ToString(quantity);
            odbcParameters[5] = new SqlParameter("@CastingWeight", SqlDbType.Decimal);
            odbcParameters[5].Value = Convert.ToString(castingWeight);
            odbcParameters[6] = new SqlParameter("@PatternCost", SqlDbType.Decimal);
            odbcParameters[6].Value = Convert.ToString(patternCost);
            odbcParameters[7] = new SqlParameter("@MachiningCost", SqlDbType.Decimal);
            odbcParameters[7].Value = Convert.ToString(machiningCost);
            odbcParameters[8] = new SqlParameter("@ModificationCost", SqlDbType.Decimal);
            odbcParameters[8].Value = Convert.ToString(modificationCost);
            odbcParameters[9] = new SqlParameter("@TotalCost", SqlDbType.Decimal);
            odbcParameters[9].Value = Convert.ToString(totalCost);
            odbcParameters[10] = new SqlParameter("@Others", SqlDbType.VarChar);
            odbcParameters[10].Value = Convert.ToString(others);
            odbcParameters[11] = new SqlParameter("@DeliveryDateTime", SqlDbType.DateTime);
            odbcParameters[11].Value = Convert.ToString(DeliveryDateTime);
            odbcParameters[12] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            odbcParameters[12].Value = Convert.ToString(remarks);

            return _conn.ExecuteNonQuery(query, odbcParameters);

        }

        public bool DeleteWorkOrder(int id)
        {
            string query = @"DELETE FROM workorder WHERE id = @id";
            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = Convert.ToString(id);
            return _conn.ExecuteNonQuery(query, odbcParameters);
        }

        public bool UpdateWorkOrder(int id, int customerId, string description, string materialId,
                                    int quantity, int castingWeight, decimal patternCost,
                                    decimal machiningCost, decimal modificationCost,
                                    decimal totalCost, string others, DateTime DeliveryDateTime,
                                    string remarks)
        {
            string query =
                @"UPDATE workorder
                SET
                Id = @id,
                CustomerId = @CustomerId,
                Description = @Description,
                MaterialId = @MaterialId,
                Quantity = @Quantity,
                CastingWeight = @CastingWeight,
                PatternCost = @PatternCost,
                MachiningCost = @MachiningCost,
                ModificationCost = @ModificationCost,
                TotalCost = @TotalCost,
                Others = @Others,
                DeliveryDateTime = @DeliveryDateTime, 
                Remarks = @Remarks
                WHERE id = @id
                ";

            SqlParameter[] odbcParameters = new SqlParameter[13];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = Convert.ToString(id);
            odbcParameters[1] = new SqlParameter("@CustomerId", SqlDbType.VarChar);
            odbcParameters[1].Value = Convert.ToString(customerId);
            odbcParameters[2] = new SqlParameter("@Description", SqlDbType.VarChar);
            odbcParameters[2].Value = Convert.ToString(description);
            odbcParameters[3] = new SqlParameter("@MaterialId", SqlDbType.VarChar);
            odbcParameters[3].Value = Convert.ToString(materialId);
            odbcParameters[4] = new SqlParameter("@Quantity", SqlDbType.Int);
            odbcParameters[4].Value = Convert.ToString(quantity);
            odbcParameters[5] = new SqlParameter("@CastingWeight", SqlDbType.Decimal);
            odbcParameters[5].Value = Convert.ToString(castingWeight);
            odbcParameters[6] = new SqlParameter("@PatternCost", SqlDbType.Decimal);
            odbcParameters[6].Value = Convert.ToString(patternCost);
            odbcParameters[7] = new SqlParameter("@MachiningCost", SqlDbType.Decimal);
            odbcParameters[7].Value = Convert.ToString(machiningCost);
            odbcParameters[8] = new SqlParameter("@ModificationCost", SqlDbType.Decimal);
            odbcParameters[8].Value = Convert.ToString(modificationCost);
            odbcParameters[9] = new SqlParameter("@TotalCost", SqlDbType.Decimal);
            odbcParameters[9].Value = Convert.ToString(totalCost);
            odbcParameters[10] = new SqlParameter("@Others", SqlDbType.VarChar);
            odbcParameters[10].Value = Convert.ToString(others);
            odbcParameters[11] = new SqlParameter("@DeliveryDateTime", SqlDbType.DateTime);
            odbcParameters[11].Value = Convert.ToString(DeliveryDateTime);
            odbcParameters[12] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            odbcParameters[12].Value = Convert.ToString(remarks);

            return _conn.ExecuteNonQuery(query, odbcParameters);

        }
        public IDataReader GetTop5Materials()
        {
            string query = string.Format(@" SELECT TOP 5 MaterialId FROM Workorder GROUP BY MaterialId 
                                            ORDER BY COUNT(MaterialId) 
                                            Desc "
                                            );
            return _conn.ExecuteReader(query);
        }

        public IDataReader GetTop5Customers()
        {
            string query = string.Format(@" SELECT TOP 5 CustomerId FROM Workorder GROUP BY CustomerId 
                                            ORDER BY COUNT(CustomerId) Desc "
                                            );
            return _conn.ExecuteReader(query);
        }
    }
}
