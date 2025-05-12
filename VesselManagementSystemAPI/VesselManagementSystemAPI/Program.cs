using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VesselApi.UnitOfWork;
using VesselManagementSystemAPI.Data;
using VesselManagementSystemAPI.Repositories;
using VesselManagementSystemAPI.Services;
using VesselManagementSystemAPI.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VesselDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    // Repositories (already registered)
    container.RegisterType<ShipRepository>().As<IShipRepository>().InstancePerLifetimeScope();
    container.RegisterType<OwnerRepository>().As<IOwnerRepository>().InstancePerLifetimeScope();

    // Unit of Work
    container.RegisterType<UnitOfWork>()
             .As<IUnitOfWork>()
             .InstancePerLifetimeScope();

    // Services
    container.RegisterType<ShipService>().As<IShipService>().InstancePerLifetimeScope();
    container.RegisterType<OwnerService>().As<IOwnerService>().InstancePerLifetimeScope();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
