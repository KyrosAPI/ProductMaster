using System;

namespace Kyros.ProductMaster.BusinessModel.Entities
{
    [Serializable]
    public sealed class ProductUserEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product user identifier.
        /// </summary>
        /// <value>
        /// The product user identifier.
        /// </value>
        public long ProductUserId { get; set; }


        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public ProductEntity Product { get; set; }

        /// <summary>
        /// Gets or sets the product user code.
        /// </summary>
        /// <value>
        /// The product user code.
        /// </value>
        public string ProductUserCode { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the kast.
        /// </summary>
        /// <value>
        /// The name of the kast.
        /// </value>
        public string KastName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
