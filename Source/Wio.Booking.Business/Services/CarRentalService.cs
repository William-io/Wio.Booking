using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Business.Models.Validations;

namespace Wio.Booking.Business.Services;

public class CarRentalService : BaseService, ICarRentalService
{
    private readonly ICarRentalRepository _carRentalRepository;

    public CarRentalService(ICarRentalRepository carRentalRepository, INotifier notifier) : base(notifier)
    {
        _carRentalRepository = carRentalRepository;
    }

    public async Task Add(CarRental carRental)
    {
        if (!ExecutarValidacao(new CarRentalValidation(), carRental)) return;

        await _carRentalRepository.Add(carRental);
    }

    public void Dispose()
    {
        _carRentalRepository?.Dispose();
    }

    public async Task Remover(Guid id)
    {
        await _carRentalRepository.Remover(id);
    }

    public async Task Update(CarRental carRental)
    {
        if (!ExecutarValidacao(new CarRentalValidation(), carRental)) return;

        await _carRentalRepository.Update(carRental);
    }
}