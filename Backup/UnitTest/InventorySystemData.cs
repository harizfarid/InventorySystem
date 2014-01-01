using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventorySystem.Data;

namespace UnitTest
{
    /// <summary>
    /// Summary description for InventorySystemData
    /// </summary>
    [TestClass]
    public class InventorySystemData
    {
        public InventorySystemData()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        #region WorkOrderDataAdapter

        
        public void TestConnection()
        {
            SqlServerConfig config = new SqlServerConfig();
            bool isConnected;
            isConnected = config.IsServerConnected();
        }

        
        public void GetPurchaseOrders()
        {
            PurchaseOrderDataAdapter adapter = new PurchaseOrderDataAdapter();
            IDataReader reader = adapter.GetPurchaseOrders();
        }

        #endregion
    }
}
