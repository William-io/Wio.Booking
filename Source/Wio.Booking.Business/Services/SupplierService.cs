using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Business.Models.Validations;

namespace Wio.Booking.Business.Services;

public class SupplierService : BaseService, ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;

    public SupplierService(ISupplierRepository supplierRepository, IAddressRepository addressRepository, INotifier notifier) : base(notifier)
    {
        _addressRepository = addressRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<bool> Add(Supplier supplier)
    {
        if (!ExecutarValidacao(new SupplierValidation(), supplier)
               || !ExecutarValidacao(new AddressValidation(), supplier.Address)) return false;

        if (_supplierRepository.Find(f => f.Document == supplier.Document).Result.Any())
        {
            Notificar("Já existe um fornecedor com este documento informado.");
            return false;
        }

        await _supplierRepository.Add(supplier);
        return true;
    }

    public async Task<bool> Update(Supplier supplier)
    {
        if (!ExecutarValidacao(new SupplierValidation(), supplier)) return false;

        if (_supplierRepository.Find(f => f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
        {
            Notificar("Já existe um fornecedor com este documento infomado.");
            return false;
        }

        await _supplierRepository.Update(supplier);
        return true;
    }

    public async Task UpdateAddress(Address address)
    {
        if (!ExecutarValidacao(new AddressValidation(), address)) return;

        await _addressRepository.Update(address);
    }


    public async Task<bool> Remover(Guid id)
    {
        if (_supplierRepository.GetSupplierCarsRentalAddress(id).Result.CarRentals.Any())
        {
            Notificar("O fornecedor possui produtos cadastrados!");
            return false;
        }

        var address = await _addressRepository.GetAddressBySupplier(id);

        if (address != null)
        {
            await _addressRepository.Remover(address.Id);
        }

        await _supplierRepository.Remover(id);
        return true;
    }

    public void Dispose()
    {
        _supplierRepository?.Dispose();
        _addressRepository?.Dispose();
    }
}