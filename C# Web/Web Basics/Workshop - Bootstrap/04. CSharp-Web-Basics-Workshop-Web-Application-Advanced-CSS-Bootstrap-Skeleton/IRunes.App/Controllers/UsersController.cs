using IRunes.Data;
using IRunes.Models;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.App.Controllers
{
    public class UsersController : Controller
    {
        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost(ActionName = "Login")]
        public ActionResult LoginConfirm()
        {
            using (var context = new RunesDbContext())
            {
                string username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
                string password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();

                if (username == null || password == null)
                {
                    return Redirect("/Users/Login");
                }

                var userFromContext = context.Users.FirstOrDefault(user => (user.Username == username || user.Email == username) && user.Password == this.HashPassword(password));

                if (userFromContext == null)
                {
                    return this.Redirect("/Users/Login");
                }

                this.SignIn(userFromContext.Id, userFromContext.Username, userFromContext.Email);
            }

            return this.Redirect("/");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost(ActionName = "Register")]
        public ActionResult RegisterConfirm()
        {
            using (var context = new RunesDbContext())
            {
                string username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
                string password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();
                string confirmPassword = ((ISet<string>)this.Request.FormData["confirmPassword"]).FirstOrDefault();
                string email = ((ISet<string>)this.Request.FormData["email"]).FirstOrDefault();

                if (password != confirmPassword)
                {
                    return Redirect("/Users/Register");
                }

                var user = new User
                {
                    Username = username,
                    Password = this.HashPassword(password),
                    Email = email,
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return Redirect("/Users/Login");
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
