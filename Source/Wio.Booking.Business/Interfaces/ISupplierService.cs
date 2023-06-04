using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface ISupplierService : IDisposable
{
    Task<bool> Add(Supplier supplier);
    Task<bool> Update(Supplier supplier);
    Task<bool> Remover(Guid id);

    Task UpdateAddress(Address address);
}