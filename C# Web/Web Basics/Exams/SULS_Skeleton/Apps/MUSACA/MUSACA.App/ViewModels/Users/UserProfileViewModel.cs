using MUSACA.App.ViewModels.Orders;
using System.Collections.Generic;

namespace MUSACA.App.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.Orders = new List<OrderProfileViewModel>();
        }

        public List<OrderProfileViewModel> Orders { get; set; }
    }
}
