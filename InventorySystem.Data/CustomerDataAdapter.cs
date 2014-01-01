using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace InventorySystem.Data
{
    public class CustomerDataAdapter : SqlServerConfig
    {
        private SqlServerConfig _conn;

        public CustomerDataAdapter()
        {
            _conn = new SqlServerConfig();
        }

        public IDataReader GetCustomerByCode(int id)
        {
            string query = string.Format(@"SELECT * FROM customer WHERE id = @id");
            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            odbcParameters[0].Value = Convert.ToString(id);
            return _conn.ExecuteReader(query, odbcParameters);
        }

        public IDataReader GetCustomerByEmail(string email)
        {
            string query = string.Format(@"SELECT * FROM customer WHERE email = @email");
            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@email", SqlDbType.VarChar);
            odbcParameters[0].Value = Convert.ToString(email);
            return _conn.ExecuteReader(query, odbcParameters);
        }

        public bool DeleteCustomer(string id)
        {
            string query = string.Format(@"DELETE FROM Customer WHERE ID = @id");
            SqlParameter[] odbcParameters = new SqlParameter[1];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.VarChar);
            odbcParameters[0].Value = id;
            return _conn.ExecuteNonQuery(query, odbcParameters);
        }

        public IDataReader GetCustomers()
        {
            string query = string.Format(@"SELECT * FROM customer ORDER BY Id Desc");
            return _conn.ExecuteReader(query);
        }

        public IDataReader GetMaxId()
        {
            string query = string.Format(@"SELECT MAX(Id) AS id FROM customer");
            return _conn.ExecuteReader(query);
        }

        public bool InsertCustomer(string company,string name,string phoneNo,
            string email,string fax,string address,string website,string remarks,string postcode,
            string country,int rating)
        {
            string query =
                @"INSERT INTO customer
                    (
                    Company,
                    Name,
                    PhoneNo,
                    Email,
                    Fax,
                    Address,
                    Website,
                    Remarks,
                    PostCode,
                    Country,
                    Rating)
                    VALUES
                    (
                    @company,
                    @name,
                    @phoneNo,
                    @email,
                    @fax,
                    @address,
                    @website,
                    @remarks,
                    @postcode,
                    @country,
                    @rating
                    )";
            SqlParameter[] odbcParameters = new SqlParameter[12];
            odbcParameters[0] = new SqlParameter("@company", SqlDbType.VarChar);
            odbcParameters[0].Value = Convert.ToString(company);
            odbcParameters[1] = new SqlParameter("@name", SqlDbType.VarChar);
            odbcParameters[1].Value = Convert.ToString(name);
            odbcParameters[2] = new SqlParameter("@phoneNo", SqlDbType.VarChar);
            odbcParameters[2].Value = Convert.ToString(phoneNo);
            odbcParameters[3] = new SqlParameter("@email", SqlDbType.VarChar);
            odbcParameters[3].Value = Convert.ToString(email);
            odbcParameters[4] = new SqlParameter("@fax", SqlDbType.VarChar);
            odbcParameters[4].Value = Convert.ToString(fax);
            odbcParameters[5] = new SqlParameter("@address", SqlDbType.VarChar);
            odbcParameters[6].Value = Convert.ToString(address);
            odbcParameters[6] = new SqlParameter("@website", SqlDbType.VarChar);
            odbcParameters[6].Value = Convert.ToString(website);
            odbcParameters[7] = new SqlParameter("@remarks", SqlDbType.VarChar);
            odbcParameters[7].Value = Convert.ToString(remarks);
            odbcParameters[8] = new SqlParameter("@postalCode", SqlDbType.VarChar);
            odbcParameters[8].Value = Convert.ToString(postcode);
            odbcParameters[9] = new SqlParameter("@country", SqlDbType.VarChar);
            odbcParameters[9].Value = Convert.ToString(country);
            odbcParameters[10] = new SqlParameter("@rating", SqlDbType.Int);
            odbcParameters[10].Value = Convert.ToString(rating);

            return _conn.ExecuteNonQuery(query, odbcParameters);

        }

        public bool UpdateCustomer(int id, string company, string name, string phoneNo,
    string email, string fax, string address, string website, string remarks, string postcode,
    string country, int rating)
        {
            string query =
                @"UPDATE customer
                SET
                Id = @id,
                Company = @company,
                Name = @name,
                PhoneNo = @phoneNo,
                Email = @email,
                Fax = @fax,
                Address = @address,
                Website = @website,
                Remarks = @remarks,
                PostCode = @postcode,
                Country = @country,
                Rating = @rating
                WHERE id = @id
                ";
            SqlParameter[] odbcParameters = new SqlParameter[12];
            odbcParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            odbcParameters[0].Value = Convert.ToInt32(id);
            odbcParameters[1] = new SqlParameter("@company", SqlDbType.VarChar);
            odbcParameters[1].Value = Convert.ToString(company);
            odbcParameters[2] = new SqlParameter("@name", SqlDbType.VarChar);
            odbcParameters[2].Value = Convert.ToString(name);
            odbcParameters[3] = new SqlParameter("@phoneNo", SqlDbType.VarChar);
            odbcParameters[3].Value = Convert.ToString(phoneNo);
            odbcParameters[4] = new SqlParameter("@email", SqlDbType.VarChar);
            odbcParameters[4].Value = Convert.ToString(email);
            odbcParameters[5] = new SqlParameter("@fax", SqlDbType.VarChar);
            odbcParameters[5].Value = Convert.ToString(fax);
            odbcParameters[6] = new SqlParameter("@address", SqlDbType.VarChar);
            odbcParameters[6].Value = Convert.ToString(address);
            odbcParameters[7] = new SqlParameter("@website", SqlDbType.VarChar);
            odbcParameters[7].Value = Convert.ToString(website);
            odbcParameters[8] = new SqlParameter("@remarks", SqlDbType.VarChar);
            odbcParameters[8].Value = Convert.ToString(remarks);
            odbcParameters[9] = new SqlParameter("@postcode", SqlDbType.VarChar);
            odbcParameters[9].Value = Convert.ToString(postcode);
            odbcParameters[10] = new SqlParameter("@country", SqlDbType.VarChar);
            odbcParameters[10].Value = Convert.ToString(country);
            odbcParameters[11] = new SqlParameter("@rating", SqlDbType.Int);
            odbcParameters[11].Value = Convert.ToString(rating);

            return _conn.ExecuteNonQuery(query, odbcParameters);

        }
    }
}
