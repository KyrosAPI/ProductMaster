using System.Linq;
using Kyros.ProductMaster.BusinessLogic.ProductUser;
using Kyros.ProductMaster.BusinessModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kyros.ProductMaster.UnitTest.BusinessLogic
{
    [TestClass]
    public class ProductUserLogicUnitTest
    {
        /// <summary>
        /// Manages the product user.
        /// </summary>
        [TestMethod]
        public void ManageProductUser()
        {
            var response = InitializeProductUserLogic.ManageProductUser(new ProductUserEntity
                                                                        {
                                                                            Product = new ProductEntity
                                                                                      {
                                                                                          ProductCode = "BAR2017"
                                                                                      },
                                                                            ProductUserCode = string.Empty,
                                                                            FirstName = "Dhanaraj",
                                                                            LastName = "D",
                                                                            EmailAddress = "dhanaraj.d@outlook.com",
                                                                            MobileNumber = "9994304699"
                                                                        });

            Assert.IsTrue(response.IsSuccess);
        }

        /// <summary>
        /// Manages the product user email address already exists.
        /// </summary>
        [TestMethod]
        public void ManageProductUserEmailAddressAlreadyExists()
        {
            var response = InitializeProductUserLogic.ManageProductUser(new ProductUserEntity
                                                                        {
                                                                            Product = new ProductEntity
                                                                                      {
                                                                                          ProductCode = "BAR2017"
                                                                                      },
                                                                            ProductUserCode = string.Empty,
                                                                            FirstName = "Dhanaraj",
                                                                            LastName = "D",
                                                                            EmailAddress = "dhanaraj.d@outlook.com",
                                                                            MobileNumber = "9994304699"
                                                                        });
            Assert.IsTrue(!response.IsSuccess);
        }

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        [TestMethod]
        public void GetProductUserByProductCode()
        {
            var response = InitializeProductUserLogic.GetProductUserByProductCode("BAR2017");
            Assert.IsTrue(response?.Items != null && response.Items.Any());
        }

        [TestMethod]
        public void GetProductUserByProductId()
        {
            var response = InitializeProductUserLogic.GetProductUserByProductId(1);
            Assert.IsTrue(response?.Items != null && response.Items.Any());
        }

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        [TestMethod]
        public void GetProductUserByProductUserId()
        {
            var response = InitializeProductUserLogic.GetProductUserByProductUserId(1);
            Assert.IsTrue(response != null && response.IsSuccess);
        }

        #region Initializers

        /// <summary>
        /// The initialize product user logic
        /// </summary>
        private IProductUserLogic _initializeProductUserLogic;

        /// <summary>
        /// Gets the initialize product user logic.
        /// </summary>
        /// <value>
        /// The initialize product user logic.
        /// </value>
        private IProductUserLogic InitializeProductUserLogic => _initializeProductUserLogic ?? (_initializeProductUserLogic = new ProductUserLogic());

        #endregion
    }
}
