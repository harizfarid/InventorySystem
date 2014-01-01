using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;


namespace InventorySystem.Data
{
    public class MySqlConfig
    {
        private MySqlDataAdapter _myAdapter;
        private MySqlConnection _myConnection;
        private MySqlCommand _command;


        public MySqlConfig()
        {
            _myAdapter = new MySqlDataAdapter();
            _myConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings
                    ["SolidFoundry"].ConnectionString);

        }

        private MySqlConnection OpenConnection()
        {
            if (_myConnection.State == ConnectionState.Open)
            {
                _myConnection.Close();
            }
            if (_myConnection.State == ConnectionState.Closed || _myConnection.State ==
                        ConnectionState.Broken)
            {
                    _myConnection.Open();
            }
            return _myConnection;
        }

        public bool ExecuteNonQuery(string myExecuteQuery, MySqlParameter[] mySqlParameters)
        {
                MySqlCommand myCommand = new MySqlCommand(myExecuteQuery, OpenConnection());
                myCommand.Parameters.AddRange(mySqlParameters);
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            return true;
        }

        public bool ExecuteNonQuery(string myExecuteQuery)
        {
                MySqlCommand myCommand = new MySqlCommand(myExecuteQuery, OpenConnection());
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
        
            return true;
        }


        public MySqlDataReader ExecuteReader(string query, MySqlParameter[] mySqlParameters)
        {
            {
                string mySelectQuery = query;
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(mySqlParameters);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                
                    return myReader;

            }
        }


        public MySqlDataReader ExecuteReader(string query)
        {
            {
                string mySelectQuery = query;
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;

                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    
                    return myReader;
               
             
            }
        }
    }
}
