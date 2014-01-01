using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventorySystem.Business;

namespace UnitTest
{
    /// <summary>
    /// Summary description for InventorySystemBusiness
    /// </summary>
    [TestClass]
    public class InventorySystemBusiness
    {
        public InventorySystemBusiness()
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

        [TestMethod]
        public void GetPurchaseOrderById()
        {
            PurchaseOrderModule module = new PurchaseOrderModule();
            int id = 1;
            PurchaseOrder po = new PurchaseOrder();
            po=module.GetPurchaseOrderById(id);
        }

        [TestMethod]
        public void GetPurchaseOrders()
        {
            PurchaseOrderModule module = new PurchaseOrderModule();
            int id = 1;
            PurchaseOrderCollection po = new PurchaseOrderCollection();
            //po = module.GetPurchaseOrders();
        }
    }
}
