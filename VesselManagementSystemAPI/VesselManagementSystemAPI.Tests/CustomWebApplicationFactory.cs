using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using VesselManagementSystemAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VesselManagementSystemAPI.Tests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, configBuilder) =>
            {
                configBuilder.Sources.Clear();

                configBuilder.AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"ConnectionStrings:DefaultConnection", "DataSource=:memory:"}
                });
            });

            builder.ConfigureServices(services =>
            {
                
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IDbContextOptionsConfiguration<VesselDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<VesselDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

               
                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<VesselDbContext>();

                db.Database.EnsureCreated();

                if (!db.Ships.Any())
                {
                    db.Ships.Add(new VesselManagementSystemAPI.Models.Ship
                    {
                        ShipName = "Test Ship",
                        ImoNumber = 9823123
                    });
                    db.SaveChanges();
                }
            });
        }
    }
}
