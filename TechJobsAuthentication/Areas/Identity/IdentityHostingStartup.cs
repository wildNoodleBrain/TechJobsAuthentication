using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechJobsAuthentication.Data;

[assembly: HostingStartup(typeof(TechJobsAuthentication.Areas.Identity.IdentityHostingStartup))]
namespace TechJobsAuthentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TechJobsAuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TechJobsAuthenticationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TechJobsAuthenticationContext>();
            });
        }
    }
}
