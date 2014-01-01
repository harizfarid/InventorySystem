using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem.Data
{
    public class PurchaseOrderDataAdapter : SqlServerConfig
    {
        private SqlServerConfig _conn;

        public PurchaseOrderDataAdapter()
        {
            _conn = new SqlServerConfig();
        }

        public bool IsExist(int id)
        {
            string query = @"SELECT id FROM [dbo].[PurchaseOrder] WHERE id = @id";
            SqlParameter param_id = new SqlParameter("@id", SqlDbType.Int);
            param_id.Value = id;
            SqlParameter[] param = new[] { param_id };
            IDataReader reader = ExecuteReader(query, param);
          
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public int GetMaxId()
        {
            string query = @"SELECT MAX(id) FROM [dbo].[PurchaseOrder]";

            IDataReader reader = ExecuteReader(query);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["Id"]);
            } 
            return 0;
        }

        public IDataReader GetPurchaseOrderById(int id)
        {
            string query = string.Format(@"
                                        SELECT	[Id]
                                              ,[CustomerId]
                                              ,[PONo]
                                              ,[DateCreated]
                                              ,[Quantity]
                                              ,[Remarks]
                                              ,[Price]
                                              ,[DeliveryDateTime]
                                              ,[TotalPrice]
                                              ,[CreatedBy]
                                              ,[Status]
                                          FROM [PurchaseOrder]
                                          WHERE id=@id;");

            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            odbcParameters[0].Value = id;
            return _conn.ExecuteReader(query, odbcParameters);

        }

        public IDataReader GetPurchaseOrders()
        {
            string query = string.Format(@"
                                        SELECT	[Id]
                                              ,[CustomerId]
                                              ,[PONo]
                                              ,[DateCreated]
                                              ,[Quantity]
                                              ,[Remarks]
                                              ,[Price]
                                              ,[DeliveryDateTime]
                                              ,[TotalPrice]
                                              ,[CreatedBy]
                                              ,[Status]
                                          FROM [PurchaseOrder]");
            return _conn.ExecuteReader(query);

        }

        public bool InsertPurchaseOrder(int customerId, string poNo, DateTime dateCreated
            , int quantity, string remarks, decimal price, DateTime deliveryDateTime
            , decimal totalPrice, string createdBy, int status)
        {
            string query =
                String.Format(
                    @"
INSERT INTO [PurchaseOrder]
           ([CustomerId]
           ,[PONo]
           ,[DateCreated]
           ,[Quantity]
           ,[Remarks]
           ,[Price]
           ,[DeliveryDateTime]
           ,[TotalPrice]
           ,[CreatedBy]
           ,[Status])
     VALUES
           (@customerId
           ,@poNo
           ,@dateCreated
           ,@quantity
           ,@remarks
           ,@price
           ,@deliveryDateTime
           ,@totalPrice
           ,@createdBy
           ,@status)
");
            try
            {
                SqlParameter param_company = new SqlParameter("@customerId", SqlDbType.Int);
                SqlParameter param_poNo = new SqlParameter("@poNo", SqlDbType.VarChar);
                SqlParameter param_dateCreated = new SqlParameter("@dateCreated", SqlDbType.DateTime);
                SqlParameter param_quantity = new SqlParameter("@quantity", SqlDbType.Int);
                SqlParameter param_remarks = new SqlParameter("@remarks", SqlDbType.VarChar);
                SqlParameter param_price = new SqlParameter("@price", SqlDbType.Decimal);
                SqlParameter param_deliveryDateTime = new SqlParameter("@deliveryDateTime", SqlDbType.DateTime);
                SqlParameter param_totalPrice = new SqlParameter("@totalPrice", SqlDbType.Decimal);
                SqlParameter param_createdBy = new SqlParameter("@createdBy", SqlDbType.VarChar);
                SqlParameter param_status = new SqlParameter("@status", SqlDbType.Int);

                param_company.Value = customerId;
                param_poNo.Value = poNo;
                param_dateCreated.Value = dateCreated;
                param_quantity.Value = quantity;
                param_remarks.Value = remarks;
                param_price.Value = price;
                param_deliveryDateTime.Value = deliveryDateTime;
                param_totalPrice.Value = totalPrice;
                param_createdBy.Value = createdBy;
                param_status.Value = status;

                SqlParameter[] param = new[]
                                       {
                                           param_company
                                           ,param_poNo
                                           ,param_dateCreated
                                           ,param_quantity
                                           ,param_remarks
                                           ,param_price
                                           ,param_deliveryDateTime
                                           ,param_totalPrice
                                           ,param_createdBy
                                           ,param_status
                                       };
                return ExecuteNonQuery(query, param);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdatePurchaseOrder(int id, int customerId, string poNo, DateTime dateCreated
            , int quantity, string remarks, decimal price, DateTime deliveryDateTime
            , decimal totalPrice, string createdBy, int status)
        {
            string query =
                String.Format(
                    @"
UPDATE [InventorySystem].[dbo].[PurchaseOrder]
   SET [CustomerId] = @customerId
      ,[PONo] = @poNo
      ,[DateCreated] = @dateCreated
      ,[Quantity] = @quantity
      ,[Remarks] = @remarks
      ,[Price] = @price
      ,[DeliveryDateTime] = @deliveryDateTime
      ,[TotalPrice] = @totalPrice
      ,[CreatedBy] = @createdBy
      ,[Status] = @status
 WHERE id = @id
");
            try
            {
                SqlParameter param_id = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter param_company = new SqlParameter("@customerId", SqlDbType.Int);
                SqlParameter param_poNo = new SqlParameter("@poNo", SqlDbType.VarChar);
                SqlParameter param_dateCreated = new SqlParameter("@dateCreated", SqlDbType.DateTime);
                SqlParameter param_quantity = new SqlParameter("@quantity", SqlDbType.Int);
                SqlParameter param_remarks = new SqlParameter("@remarks", SqlDbType.VarChar);
                SqlParameter param_price = new SqlParameter("@price", SqlDbType.Decimal);
                SqlParameter param_deliveryDateTime = new SqlParameter("@deliveryDateTime", SqlDbType.DateTime);
                SqlParameter param_totalPrice = new SqlParameter("@totalPrice", SqlDbType.Decimal);
                SqlParameter param_createdBy = new SqlParameter("@createdBy", SqlDbType.VarChar);
                SqlParameter param_status = new SqlParameter("@status", SqlDbType.Int);

                param_id.Value = id;
                param_company.Value = customerId;
                param_poNo.Value = poNo;
                param_dateCreated.Value = dateCreated;
                param_quantity.Value = quantity;
                param_remarks.Value = remarks;
                param_price.Value = price;
                param_deliveryDateTime.Value = deliveryDateTime;
                param_totalPrice.Value = totalPrice;
                param_createdBy.Value = createdBy;
                param_status.Value = status;

                SqlParameter[] param = new[]
                                       {
                                           param_id
                                           ,param_company
                                           ,param_poNo
                                           ,param_dateCreated
                                           ,param_quantity
                                           ,param_remarks
                                           ,param_price
                                           ,param_deliveryDateTime
                                           ,param_totalPrice
                                           ,param_createdBy
                                           ,param_status
                                       };
                return ExecuteNonQuery(query, param);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeletePurchaseOrder(int id)
        {
            string query = string.Format(@"DELETE FROM [dbo].[PurchaseOrder] WHERE Id = @id");
            SqlParameter param_id = new SqlParameter("@Id", SqlDbType.Int);
            param_id.Value = id;
            SqlParameter[] param = new[] { param_id };
            return ExecuteNonQuery(query, param);
        }
    }
}
