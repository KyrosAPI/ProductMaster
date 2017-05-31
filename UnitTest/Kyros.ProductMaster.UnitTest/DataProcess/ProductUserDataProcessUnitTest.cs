using System;
using Kyros.ProductMaster.DataProcess.ProductUser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kyros.ProductMaster.UnitTest.DataProcess
{
    [TestClass]
    public class ProductUserDataProcessUnitTest
    {
        /// <summary>
        /// Manages the product user.
        /// </summary>
        [TestMethod]
        public void ManageProductUser()
        {
            var response = InitializeProductUserDataProcess.ManageProductUser("BAR2017","", "FirstName", "LastName", "EmailAddress1@EmailAddress.com", "MobileNumber");
            Assert.IsTrue(response != null && response.Tables[0].Rows.Count > 0);
        }

        /// <summary>
        /// Manages the product user email address already exists.
        /// </summary>
        [TestMethod]
        public void ManageProductUserEmailAddressAlreadyExists()
        {
            try
            {
                var response = InitializeProductUserDataProcess.ManageProductUser("BAR2017", "", "FirstName", "LastName", "EmailAddress@EmailAddress.com", "MobileNumber");
            }
            catch (Exception exception)
            {
               Assert.IsTrue(exception.Message == "EMAIL_ADDRESS_ALREADY_EXISTS");
            }
        }

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        [TestMethod]
        public void GetProductUserByProductCode()
        {
            var response = InitializeProductUserDataProcess.GetProductUserByProductCode("BAR2017");
            Assert.IsTrue(response != null && response.Tables[0].Rows.Count > 0);
        }

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        [TestMethod]
        public void GetProductUserByProductId()
        {
            var response = InitializeProductUserDataProcess.GetProductUserByProductId(1);
            Assert.IsTrue(response != null && response.Tables[0].Rows.Count > 0);
        }

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        [TestMethod]
        public void GetProductUserByProductUserId()
        {
            var response = InitializeProductUserDataProcess.GetProductUserByProductUserId(100001);
            Assert.IsTrue(response != null && response.Tables[0].Rows.Count > 0);
        }

        #region Initializers

        /// <summary>
        /// The initialize product user data process
        /// </summary>
        private IProductUserDataProcess _initializeProductUserDataProcess;

        /// <summary>
        /// Gets the initialize product user data process.
        /// </summary>
        /// <value>
        /// The initialize product user data process.
        /// </value>
        private IProductUserDataProcess InitializeProductUserDataProcess => _initializeProductUserDataProcess ?? (_initializeProductUserDataProcess =  new ProductUserDataProcess());
       

        #endregion
    }
}
