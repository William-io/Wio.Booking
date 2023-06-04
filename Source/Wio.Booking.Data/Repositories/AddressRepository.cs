using Microsoft.EntityFrameworkCore;
using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Data.Context;

namespace Wio.Booking.Data.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(DataContext context) : base(context) { }

    public async Task<Address> GetAddressBySupplier(Guid supplierId)
    {
        return await Db.Address.AsNoTracking()
                .FirstOrDefaultAsync(f => f.SupplierId == supplierId);
    }
}