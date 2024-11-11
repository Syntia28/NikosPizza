using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikosPizza.Api.Routes
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}