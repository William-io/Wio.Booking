using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface ICarRentalService : IDisposable
{
    Task Add(CarRental carRental);
    Task Update(CarRental carRental);
    Task Remover(Guid id);
}