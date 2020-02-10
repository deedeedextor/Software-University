using SIS.MvcFramework.Attributes.Validation;

namespace PANDA.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {

        private const string UsernameErrorMessage = "Username must be between 5 and 20 symbols!";
        private const string EmailErrorMessage = "Email must be between 5 and 20 symbols!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}
