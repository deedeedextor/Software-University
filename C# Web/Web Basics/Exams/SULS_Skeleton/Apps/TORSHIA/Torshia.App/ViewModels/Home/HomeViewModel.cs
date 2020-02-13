using System.Collections.Generic;

namespace Torshia.App.ViewModels.Home
{
    public class HomeViewModel
    {
        public string Username { get; set; }
        
        public IEnumerable<HomeTaskViewModel> Tasks { get; set; }
    }
}
