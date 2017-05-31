using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Kyros.ProductMaster.BusinessLogic.ProductUser;
using Kyros.ProductMaster.BusinessModel.Collections;
using Kyros.ProductMaster.BusinessModel.Entities;
using Kyros.ProductMaster.WebApi.Models;

namespace Kyros.ProductMaster.WebApi.Controllers
{
    public sealed class ProductUserController : ApiController
    {
        /// <summary>
        /// Manages the product user.
        /// </summary>
        /// <param name="productUserModel">The product user model.</param>
        /// <returns></returns>
        [ActionName("ManageProductUser"), HttpPost]
        public HttpResponseMessage ManageProductUser(ProductUserModel productUserModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var response = InitializeProductUserLogic.ManageProductUser(ConvertProductUserModelToEntity(productUserModel));
                return Request.CreateResponse(response != null && !response.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, ConvertProductUserEntityToProductUserModel(response));
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        [ActionName("GetProductUserByProductCode"), HttpGet]
        public HttpResponseMessage GetProductUserByProductCode(string productCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productCode))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product code should not be empty");
                }

                var response = InitializeProductUserLogic.GetProductUserByProductCode(productCode);
                return Request.CreateResponse(response?.Items != null && response.Items.Any() ? HttpStatusCode.OK : HttpStatusCode.BadRequest, response?.Items != null && response.Items.Any() ? ConvertProductUserCollectionToList(response) : null);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [ActionName("GetProductUserByProductId"), HttpGet]
        public HttpResponseMessage GetProductUserByProductId(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product id should be greater than zero");
                }

                var response = InitializeProductUserLogic.GetProductUserByProductId(productId);
                return Request.CreateResponse(response?.Items != null && response.Items.Any() ? HttpStatusCode.OK : HttpStatusCode.BadRequest, response?.Items != null && response.Items.Any() ? ConvertProductUserCollectionToList(response) : null);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        [ActionName("GetProductUserByProductId"), HttpGet]
        public HttpResponseMessage GetProductUserByProductUserId(long productUserId)
        {
            try
            {
                if (productUserId <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product user id should be greater than zero");
                }

                var response = InitializeProductUserLogic.GetProductUserByProductUserId(productUserId);
                return Request.CreateResponse(response != null && !response.IsSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest, ConvertProductUserEntityToProductUserModel(response));
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
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

        #region Private Methods

        /// <summary>
        /// Converts the product user collection to list.
        /// </summary>
        /// <param name="productUsers">The product users.</param>
        /// <returns></returns>
        private static IList<ProductUserModel> ConvertProductUserCollectionToList(ProductUserCollection productUsers)
        {
            if (productUsers?.Items == null || !productUsers.Items.Any())
            {
                return null;
            }

            return productUsers.Items.Select(ConvertProductUserEntityToProductUserModel).ToList();
        }

        /// <summary>
        /// Converts the product user model to entity.
        /// </summary>
        /// <param name="productUserModel">The product user model.</param>
        /// <returns></returns>
        private static ProductUserEntity ConvertProductUserModelToEntity(ProductUserModel productUserModel)
        {
            return new ProductUserEntity
            {
                ProductUserId = productUserModel.ProductUserId,
                FirstName = productUserModel.FirstName,
                LastName = productUserModel.LastName,
                MobileNumber = $"{productUserModel.MobileCountryId}{productUserModel.MobileNumber}",
                EmailAddress = productUserModel.EmailAddress,
                Product = new ProductEntity
                {
                    ProductCode = productUserModel.Product.ProductCode
                },
            };
        }

        /// <summary>
        /// Converts the product user entity to product user model.
        /// </summary>
        /// <param name="productUserEntity">The product user entity.</param>
        /// <returns></returns>
        private static ProductUserModel ConvertProductUserEntityToProductUserModel(ProductUserEntity productUserEntity)
        {
            var response = productUserEntity == null ? null : new ProductUserModel
            {
                ProductUserId = productUserEntity.ProductUserId,
                ProductUserCode = productUserEntity.ProductUserCode,
                FirstName = productUserEntity.FirstName,
                LastName = productUserEntity.LastName,
                MobileNumber = productUserEntity.MobileNumber,
                EmailAddress = productUserEntity.EmailAddress,
                
                IsSuccess = productUserEntity.IsSuccess,
                Message = productUserEntity.Message
            };

            if (response != null && productUserEntity.Product != null)
            {
                response.Product = new ProductModel
                                   {
                                       IsSuccess = true,
                                       Message = string.Empty,
                                       ProductCode = productUserEntity.Product.ProductCode,
                                       ProductDescription = productUserEntity.Product.ProductDescription,
                                       ProductId = productUserEntity.Product.ProductId
                                   };
            }

            return response;
        }

        #endregion
    }
}
