namespace Kyros.ProductMaster.WebApi.Constants
{
    public static class ProductUserConstants
    {
        /// <summary>
        /// The error message required first name
        /// </summary>
        public const string ErrorMessage_Required_FirstName = "First name should not be empty";

        /// <summary>
        /// The error message required last name
        /// </summary>
        public const string ErrorMessage_Required_LastName = "Last name should not be empty";

        /// <summary>
        /// The error message length first name
        /// </summary>
        public const string ErrorMessage_Length_FirstName = "The maximumn length of First name should be 50";

        /// <summary>
        /// The error message required mobile number
        /// </summary>
        public const string ErrorMessage_Required_MobileNumberCountryCode = "Mobile number country code should be greater than zero";

        /// <summary>
        /// The error message required mobile number
        /// </summary>
        public const string ErrorMessage_Required_MobileNumber = "Mobile Number should not be empty";

        /// <summary>
        /// The error message required email address
        /// </summary>
        public const string ErrorMessage_Required_EmailAddress = "Email address should not be empty";

        /// <summary>
        /// The regular expression email address
        /// </summary>
        public const string Regular_Expression_EmailAddress = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        /// <summary>
        /// The error message regular email address
        /// </summary>
        public const string ErrorMessage_Regular_EmailAddress = "Invalid email address";

        /// <summary>
        /// The error message length last name
        /// </summary>
        public const string ErrorMessage_Length_LastName = "The maximumn length of Last name should be 50";

        /// <summary>
        /// The error message mobile number country code
        /// </summary>
        public const string ErrorMessage_MobileNumber_CountryCode = "Invalid country code";


    }
}