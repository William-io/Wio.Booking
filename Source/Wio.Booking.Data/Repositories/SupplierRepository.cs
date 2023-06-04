using Microsoft.EntityFrameworkCore;
using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Data.Context;

namespace Wio.Booking.Data.Repositories;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(DataContext dataContext) : base(dataContext) { }

    public async Task<Supplier> GetSupplierAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Supplier> GetSupplierCarsRentalAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
                .Include(c => c.CarRentals)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}