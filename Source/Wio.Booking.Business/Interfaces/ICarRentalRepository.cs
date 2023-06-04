using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface ICarRentalRepository : IRepository<CarRental>
{
    Task<IEnumerable<CarRental>> GetCarRentalBySupplier(Guid supplierId);
    Task<IEnumerable<CarRental>> GetCarsRentalSuppliers();
    Task<CarRental> GetCarRentalSupplier(Guid id);
}