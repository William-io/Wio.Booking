using FluentValidation;
using Wio.Booking.Business.Models.Validations.Document;

namespace Wio.Booking.Business.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(f => f.Name)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(f => f.SupplierType == SupplierType.Juridico, () =>
        {
            RuleFor(f => f.Document.Length).Equal(CnpjValidation.CnpjSize)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CnpjValidation.Validation(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        });
    }
}