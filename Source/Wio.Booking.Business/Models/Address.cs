namespace Wio.Booking.Business.Models;

public class Address : Entity
{
    public Guid SupplierId { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Complement { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;

    /* EF Relation */
    public Supplier Supplier { get; set; } = null!;
}