namespace Wio.Booking.Business.Models;

public class Supplier : Entity
{
    public string Name { get; set; } = null!;
    public string Document { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public bool Active { get; set; }
    //1:N
    public IEnumerable<CarRental>? CarRentals { get; set; }
    //Fore
    public SupplierType? SupplierType { get; set; }
}