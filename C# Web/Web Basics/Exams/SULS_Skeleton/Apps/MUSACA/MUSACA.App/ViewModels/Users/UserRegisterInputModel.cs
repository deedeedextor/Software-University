using SIS.MvcFramework.Attributes.Validation;

namespace MUSACA.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Username length must be between 5 and 20!";
        private const string PasswordErrorMessage = "Password length must be between 6 and 20!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
