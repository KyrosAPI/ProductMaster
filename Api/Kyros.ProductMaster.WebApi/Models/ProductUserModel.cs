using System.ComponentModel.DataAnnotations;
using static Kyros.ProductMaster.WebApi.Constants.ProductUserConstants;

namespace Kyros.ProductMaster.WebApi.Models
{
    public sealed class ProductUserModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the product user identifier.
        /// </summary>
        /// <value>
        /// The product user identifier.
        /// </value>
        public long ProductUserId { get; set; }

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
       [StringLength(50,ErrorMessage = ErrorMessage_Length_FirstName), Required(AllowEmptyStrings = false,ErrorMessage = ErrorMessage_Required_FirstName)]
       public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage_Required_LastName), StringLength(50, ErrorMessage = ErrorMessage_Length_LastName)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile country identifier.
        /// </summary>
        /// <value>
        /// The mobile country identifier.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage_Required_MobileNumberCountryCode),Range(1,300,ErrorMessage = ErrorMessage_MobileNumber_CountryCode)]
        public int MobileCountryId { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        [Required(AllowEmptyStrings = false,ErrorMessage = ErrorMessage_Required_MobileNumber)]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required(AllowEmptyStrings = false,ErrorMessage = ErrorMessage_Required_EmailAddress),RegularExpression(Regular_Expression_EmailAddress, ErrorMessage = ErrorMessage_Regular_EmailAddress)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public ProductModel Product { get; set; }
    }
}