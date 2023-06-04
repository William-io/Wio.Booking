using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address> GetAddressBySupplier(Guid supplierId);
}