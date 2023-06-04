using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Notifications;
using Wio.Booking.Business.Services;
using Wio.Booking.Data.Context;
using Wio.Booking.Data.Repositories;

namespace Wio.Booking.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<DataContext>();
        // services.AddScoped<ICarRentalRepository, CarRentalRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        // services.AddScoped<IAddressRepository, AddressRepository>();

        // services.AddScoped<INotifier, Notifier>();
        // services.AddScoped<ISupplierService, SupplierService>();
        // services.AddScoped<ICarRentalService, CarRentalService>();
        return services;
    }
}