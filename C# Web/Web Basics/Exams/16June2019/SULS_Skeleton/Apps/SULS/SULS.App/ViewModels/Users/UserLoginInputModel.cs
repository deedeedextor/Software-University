using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Users
{
    public class UserLoginInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username' length must be between 5 and 20!")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Password's lengthmust be between 6 and 20!")]
        public string Password { get; set; }
    }
}
