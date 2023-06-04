using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wio.Booking.API.ViewModels;
using Wio.Booking.Business.Interfaces;

namespace Wio.Booking.API.Controllers;

[Route("api/suppliers")]
public class SupplierController : MainController
{
    public readonly ISupplierRepository _supplierRepository;
    public readonly IMapper _mapper;

    public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierViewModel>> GetAll()
    {
        var supplier = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

        return supplier;
    }
}