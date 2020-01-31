using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username's length must be between 5 and 20!")]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Password's length must be between 6 and 20!")]
        public string Password { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Password's length must be between 6 and 20!")]
        public string ConfirmPassword { get; set; }
    }
}
