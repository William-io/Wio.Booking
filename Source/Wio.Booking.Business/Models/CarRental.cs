namespace Wio.Booking.Business.Models;

public class CarRental : Entity
{
    public Guid SupplierId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Image { get; set; }
    public decimal Value { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool Active { get; set; }

    public Supplier Supplier { get; set; } = null!;
}