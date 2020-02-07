using SIS.MvcFramework.Attributes.Validation;

namespace MUSACA.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Username length must be between 5 and 20!"; 
        private const string EmailErrorMessage = "Email length must be between 5 and 50!";
        private const string PasswordErrorMessage = "Password length must be between 6 and 20!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        [StringLengthSis(5, 50, EmailErrorMessage)]
        public string Email { get; set; }

        [RequiredSis]
        [PasswordSis(PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}
