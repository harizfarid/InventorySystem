using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace InventorySystem.Data
{
    public class SqlServerConfig : IDisposable
    {
        private SqlDataAdapter _myAdapter;
        private SqlConnection _myConnection;
        private SqlCommand _command;
        private bool disposed = false;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings
            ["InventorySystem"].ConnectionString;

        public SqlServerConfig()
        {
            Dispose(true);
        }

        private SqlConnection OpenConnection()
        {
            if (_myConnection.State == ConnectionState.Open)
            {
                _myConnection.Close();
                this.Dispose(true);
            }
            if (_myConnection.State == ConnectionState.Closed || _myConnection.State ==
                        ConnectionState.Broken)
            {
                _myConnection.Open();
            }
            return _myConnection;
        }

        public bool ExecuteNonQuery(string executeQuery, SqlParameter[] sqlParameters)
        {
            _myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(executeQuery, OpenConnection());
            myCommand.Parameters.AddRange(sqlParameters);
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            return true;
        }

        public bool ExecuteNonQuery(string myExecuteQuery)
        {
            _myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(myExecuteQuery, OpenConnection());
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            return true;
        }


        public IDataReader ExecuteReader(string query, SqlParameter[] sqlParameters)
        {
            
                string mySelectQuery = query;
                SqlCommand myCommand = new SqlCommand();
                SqlDataReader myReader;
                _myConnection = new SqlConnection(connectionString);
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameters);
                myReader = myCommand.ExecuteReader();
                return myReader;



            
        }


        public IDataReader ExecuteReader(string query)
        {
                string mySelectQuery = query;
                SqlCommand myCommand = new SqlCommand();
            SqlDataReader myReader;
                _myConnection = new SqlConnection(connectionString);
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myReader = myCommand.ExecuteReader();
                return myReader;
        }

        public bool IsServerConnected()
        {
            using (this._myConnection)
            {
                try
                {
                    _myConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    // not really necessary
                    _myConnection.Close();
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {

            Dispose(true);

            // tell the GC that the Finalize process no longer needs
            // to be run for this object.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (!this.disposed)
            {
                if (disposeManagedResources)
                {

                    if (_myConnection != null)
                    {
                        _myConnection.Dispose();
                        _myConnection.Close();
                        _myConnection = null;
                    }
                }
                disposed = true;
            }
            else
            {

            }
        }

        #endregion
    }
}
