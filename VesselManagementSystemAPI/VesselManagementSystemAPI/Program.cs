using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VesselApi.UnitOfWork;
using VesselManagementSystemAPI.Data;
using VesselManagementSystemAPI.Repositories;
using VesselManagementSystemAPI.Services;
using VesselManagementSystemAPI.UnitOfWork;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<VesselDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Host.ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterType<ShipRepository>().As<IShipRepository>().InstancePerLifetimeScope();
            container.RegisterType<OwnerRepository>().As<IOwnerRepository>().InstancePerLifetimeScope();
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<ShipService>().As<IShipService>().InstancePerLifetimeScope();
            container.RegisterType<OwnerService>().As<IOwnerService>().InstancePerLifetimeScope();
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}