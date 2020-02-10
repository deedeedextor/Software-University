using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using PANDA.Services;
using PANDA.App.ViewModels.Users;

namespace PANDA.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var userFromDb = this.userService
                .GetUserByUsernameAndPassword(model.Username, model.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel model)
        {
            if (!ModelState.IsValid || model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}