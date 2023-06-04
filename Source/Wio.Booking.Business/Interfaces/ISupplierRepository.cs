using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddress(Guid id);
    Task<Supplier> GetSupplierCarsRentalAddress(Guid id);
}