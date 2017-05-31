using System.Data;

namespace Kyros.ProductMaster.DataProcess.ProductUser
{
    public interface IProductUserDataProcess
    {
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
        DataSet ManageProductUser(string productCode, string productUserCode, string firstName, string lastName, string emailAddress, string mobileNumber);

        /// <summary>
        /// Gets the product user by product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        DataSet GetProductUserByProductCode(string productCode);

        /// <summary>
        /// Gets the product user by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        DataSet GetProductUserByProductId(int productId);

        /// <summary>
        /// Gets the product user by product user identifier.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        DataSet GetProductUserByProductUserId(long productUserId);
    }
}