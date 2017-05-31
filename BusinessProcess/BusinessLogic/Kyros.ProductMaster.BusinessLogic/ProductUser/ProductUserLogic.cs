using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Kyros.ProductMaster.BusinessLogic.Resource;
using Kyros.ProductMaster.BusinessModel.Collections;
using Kyros.ProductMaster.BusinessModel.Entities;
using Kyros.ProductMaster.DataProcess.ProductUser;

namespace Kyros.ProductMaster.BusinessLogic.ProductUser
{
    public sealed class ProductUserLogic : IProductUserLogic
    {
        #region Implementation of IProductUserLogic

        /// <summary>
        /// Manages the product user.
        /// </summary>
        /// <param name="productUserEntity">The product user entity.</param>
        /// <returns></returns>
        public ProductUserEntity ManageProductUser(ProductUserEntity productUserEntity)
        {
            try
            {
                return ConvertDataSetToProductUserEntity(InitializeProductUserDataProcess.ManageProductUser(productUserEntity.Product.ProductCode, productUserEntity.ProductUserCode, productUserEntity.FirstName, productUserEntity.LastName, productUserEntity.EmailAddress, productUserEntity.MobileNumber));
            }
            catch (Exception exception)
            {
                return new ProductUserEntity { IsSuccess = false, Message = exception.Message == BusinessLogicResource.EMAIL_ADDRESS_ALREADY_EXISTS ? BusinessLogicResource.ERROR_EMAIL_ADDRESS_ALREADY_EXISTS : exception.InnerException?.Message ?? exception.Message };
            }
        }

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        public ProductUserCollection GetProductUserByProductCode(string productCode)
        {
            try
            {
                return ConvertDataSetToProductUserCollection(InitializeProductUserDataProcess.GetProductUserByProductCode(productCode));
            }
            catch (Exception exception)
            {
                return new ProductUserCollection { IsSuccess = false, Message = exception.InnerException?.Message ?? exception.Message };
            }
        }

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public ProductUserCollection GetProductUserByProductId(int productId)
        {
            try
            {
                return ConvertDataSetToProductUserCollection(InitializeProductUserDataProcess.GetProductUserByProductId(productId));
            }
            catch (Exception exception)
            {
                return new ProductUserCollection { IsSuccess = false, Message = exception.InnerException?.Message ?? exception.Message };
            }
        }

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        public ProductUserEntity GetProductUserByProductUserId(long productUserId)
        {
            try
            {
                return ConvertDataSetToProductUserEntity(InitializeProductUserDataProcess.GetProductUserByProductUserId(productUserId));
            }
            catch (Exception exception)
            {
                return new ProductUserEntity { IsSuccess = false, Message = exception.Message == BusinessLogicResource.EMAIL_ADDRESS_ALREADY_EXISTS ? BusinessLogicResource.ERROR_EMAIL_ADDRESS_ALREADY_EXISTS : exception.InnerException?.Message ?? exception.Message };
            }
        }

        #endregion

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
        private IProductUserDataProcess InitializeProductUserDataProcess => _initializeProductUserDataProcess ?? (_initializeProductUserDataProcess = new ProductUserDataProcess());

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts the data set to product user entity.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        private static ProductUserEntity ConvertDataSetToProductUserEntity(DataSet dataSet)
        {
            ProductUserEntity productUserEntity = null;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                productUserEntity = new ProductUserEntity
                {
                    ProductUserId = dataRow[BusinessLogicResource.ProductUserId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[BusinessLogicResource.ProductUserId], CultureInfo.InvariantCulture),
                    Product = new ProductEntity
                    {
                        ProductId = dataRow[BusinessLogicResource.ProductId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[BusinessLogicResource.ProductId], CultureInfo.InvariantCulture),
                        ProductCode = dataRow[BusinessLogicResource.ProductCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductCode], CultureInfo.InvariantCulture),
                        ProductDescription = dataRow[BusinessLogicResource.ProductDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductDescription], CultureInfo.InvariantCulture)
                    },
                    ProductUserCode = dataRow[BusinessLogicResource.ProductUserCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductUserCode], CultureInfo.InvariantCulture),
                    FirstName = dataRow[BusinessLogicResource.FirstName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.FirstName], CultureInfo.InvariantCulture),
                    LastName = dataRow[BusinessLogicResource.LastName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.LastName], CultureInfo.InvariantCulture),
                    FullName = dataRow[BusinessLogicResource.FullName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.FullName], CultureInfo.InvariantCulture),
                    EmailAddress = dataRow[BusinessLogicResource.EmailAddress] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.EmailAddress], CultureInfo.InvariantCulture),
                    MobileNumber = dataRow[BusinessLogicResource.MobileNumber] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.MobileNumber], CultureInfo.InvariantCulture),
                    IsActive = dataRow[BusinessLogicResource.IsActive] != DBNull.Value && Convert.ToBoolean(dataRow[BusinessLogicResource.IsActive], CultureInfo.InvariantCulture),
                    IsSuccess = true,
                    Message = string.Empty
                };
            }

            return productUserEntity;
        }

        /// <summary>
        /// Converts the data set to product user collection.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        private static ProductUserCollection ConvertDataSetToProductUserCollection(DataSet dataSet)
        {
            var response = new ProductUserCollection
            {
                Items = new List<ProductUserEntity>(),
                IsSuccess = dataSet.Tables[0].Rows.Count > 0
            };

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                response.Items.Add(new ProductUserEntity
                {
                    ProductUserId = dataRow[BusinessLogicResource.ProductUserId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[BusinessLogicResource.ProductUserId], CultureInfo.InvariantCulture),
                    Product = new ProductEntity
                    {
                        ProductId = dataRow[BusinessLogicResource.ProductId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[BusinessLogicResource.ProductId], CultureInfo.InvariantCulture),
                        ProductCode = dataRow[BusinessLogicResource.ProductCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductCode], CultureInfo.InvariantCulture),
                        ProductDescription = dataRow[BusinessLogicResource.ProductDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductDescription], CultureInfo.InvariantCulture),
                        IsSuccess = true
                    },
                    ProductUserCode = dataRow[BusinessLogicResource.ProductUserCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.ProductUserCode], CultureInfo.InvariantCulture),
                    FirstName = dataRow[BusinessLogicResource.FirstName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.FirstName], CultureInfo.InvariantCulture),
                    LastName = dataRow[BusinessLogicResource.LastName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.LastName], CultureInfo.InvariantCulture),
                    FullName = dataRow[BusinessLogicResource.FullName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.FullName], CultureInfo.InvariantCulture),
                    EmailAddress = dataRow[BusinessLogicResource.EmailAddress] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.EmailAddress], CultureInfo.InvariantCulture),
                    MobileNumber = dataRow[BusinessLogicResource.MobileNumber] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[BusinessLogicResource.MobileNumber], CultureInfo.InvariantCulture),
                    IsActive = dataRow[BusinessLogicResource.IsActive] != DBNull.Value && Convert.ToBoolean(dataRow[BusinessLogicResource.IsActive], CultureInfo.InvariantCulture),
                    IsSuccess = true,
                    Message = string.Empty
                });
            }


            return response;
        }

        #endregion


    }
}
