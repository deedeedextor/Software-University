using PANDA.App.ViewModels.Packages;
using PANDA.Models.Enums;
using PANDA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace PANDA.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packageService, IUsersService userService)
        {
            this.packagesService = packageService;
            this.usersService = userService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var users = this.usersService.GetUsernames();

            return this.View(users);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PackageCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packagesService.CreatePackage(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packagesService.GetAllPackagesByStatus(PackageStatus.Pending)
                .Select(p => new PackageViewModel
                {
                    Description = p.Description,
                    Id = p.Id,
                    Weight = p.Weight,
                    ShippingAddress = p.ShippingAddress,
                    RecipientName = p.Recipient.Username,
                }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages});
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = this.packagesService.GetAllPackagesByStatus(PackageStatus.Delivered)
                 .Select(p => new PackageViewModel
                 {
                     Description = p.Description,
                     Id = p.Id,
                     Weight = p.Weight,
                     ShippingAddress = p.ShippingAddress,
                     RecipientName = p.Recipient.Username,
                 }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packagesService.Deliver(id);

            return this.Redirect("/Packages/Delivered");
        }
    }
}
