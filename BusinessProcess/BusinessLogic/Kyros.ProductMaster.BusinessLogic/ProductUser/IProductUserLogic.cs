using Kyros.ProductMaster.BusinessModel.Collections;
using Kyros.ProductMaster.BusinessModel.Entities;

namespace Kyros.ProductMaster.BusinessLogic.ProductUser
{
    public interface IProductUserLogic
    {
        /// <summary>
        /// Manages the product user.
        /// </summary>
        /// <param name="productUserEntity">The product user entity.</param>
        /// <returns></returns>
        ProductUserEntity ManageProductUser(ProductUserEntity productUserEntity);

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        ProductUserCollection GetProductUserByProductCode(string productCode);

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        ProductUserCollection GetProductUserByProductId(int productId);

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        ProductUserEntity GetProductUserByProductUserId(long productUserId);
    }
}
