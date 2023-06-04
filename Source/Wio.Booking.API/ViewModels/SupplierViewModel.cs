using System.ComponentModel.DataAnnotations;

namespace Wio.Booking.API.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Document { get; set; } = null!;

        public int SupplierType { get; set; }

        public AddressViewModel Address { get; set; } = null!;

        public bool Active { get; set; }

        public IEnumerable<CarRentalViewModel> CarRentals { get; set; } = null!;
    }
}