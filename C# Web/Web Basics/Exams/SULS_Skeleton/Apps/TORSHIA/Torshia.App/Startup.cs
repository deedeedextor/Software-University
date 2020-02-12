using Microsoft.EntityFrameworkCore;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using Torshia.Services;
using Totshia.Data;

namespace Torshia.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new TORSHIAContext())
            {
                db.Database.Migrate();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<ITasksService, TasksService>();
            serviceProvider.Add<IReportsService, ReportsService>();
        }
    }
}
