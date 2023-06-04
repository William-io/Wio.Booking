using Microsoft.EntityFrameworkCore;
using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Data.Context;

namespace Wio.Booking.Data.Repositories;

public class CarRentalRepository : Repository<CarRental>, ICarRentalRepository
{
    protected CarRentalRepository(DataContext db) : base(db) { }

    public async Task<IEnumerable<CarRental>> GetCarRentalBySupplier(Guid supplierId)
    {
        return await Find(p => p.SupplierId == supplierId);
    }

    public async Task<CarRental> GetCarRentalSupplier(Guid id)
    {
        return await Db.CarRentals.AsNoTracking().Include(f => f.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<CarRental>> GetCarsRentalSuppliers()
    {
        return await Db.CarRentals.AsNoTracking().Include(f => f.Supplier)
                .OrderBy(p => p.Name).ToListAsync();
    }
}