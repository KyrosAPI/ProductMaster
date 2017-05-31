using System.Collections.Generic;
using System.Data;
using Kyros.ProductMaster.DataAccess;
using Kyros.ProductMaster.DataProcess.Resource;

namespace Kyros.ProductMaster.DataProcess.ProductUser
{
    public sealed class ProductUserDataProcess : IProductUserDataProcess
    {
        #region Implementation of IProductUserDataProcess

        /// <summary>
        /// Manages the product user.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <param name="productUserCode">The product user code.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <returns></returns>
        public DataSet ManageProductUser(string productCode, string productUserCode, string firstName, string lastName, string emailAddress, string mobileNumber)
        {
            return InitializeDataAccessLayer.ExecuteDataSet(DataProcessResource.usp_ManageProductUser, new Dictionary<string, object>
                {
                    {DataProcessResource.spparam_ProductCode, productCode},
                    {DataProcessResource.spparam_productUserCode, productUserCode},
                    {DataProcessResource.spparam_FirstName, firstName},
                    {DataProcessResource.spparam_LastName, lastName},
                    {DataProcessResource.spparam_EmailAddress, emailAddress},
                    {DataProcessResource.spparam_MobileNumber, mobileNumber}
                });
        }

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        public DataSet GetProductUserByProductCode(string productCode)
        {
            return InitializeDataAccessLayer.ExecuteDataSet(DataProcessResource.usp_GetProductUserByProductCode, new Dictionary<string, object>
                {
                    {DataProcessResource.spparam_ProductCode, productCode}
                });
        }

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public DataSet GetProductUserByProductId(int productId)
        {
            return InitializeDataAccessLayer.ExecuteDataSet(DataProcessResource.usp_GetProductUserByProductId, new Dictionary<string, object>
                                                                                                              {
                                                                                                                  {
                                                                                                                      DataProcessResource.spparam_ProductId,productId
                                                                                                                  }
                                                                                                              });
        }

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        public DataSet GetProductUserByProductUserId(long productUserId)
        {
            return InitializeDataAccessLayer.ExecuteDataSet(DataProcessResource.usp_GetProductUserByProductUserId, new Dictionary<string, object>
                {
                    {DataProcessResource.spparam_ProductUserId, productUserId}
                });
        }

        #endregion

        #region Initializers

        /// <summary>
        /// The initialize data access layer
        /// </summary>
        private IDataAccessLayer _initializeDataAccessLayer;

        /// <summary>
        /// Gets the initialize data access layer.
        /// </summary>
        /// <value>
        /// The initialize data access layer.
        /// </value>
        private IDataAccessLayer InitializeDataAccessLayer => _initializeDataAccessLayer ?? (_initializeDataAccessLayer = new DataAccessLayer());

        #endregion
    }
}
