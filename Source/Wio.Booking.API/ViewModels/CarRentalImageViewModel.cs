﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Wio.Booking.API.Extensions;

namespace Wio.Booking.API.ViewModels
{
    // Binder personalizado para envio de IFormFile e ViewModel dentro de um FormData compatível com
    // .NET Core 3.1 ou superior (system.text.json)
    [ModelBinder(BinderType = typeof(CarRentalModelBinder))]
    public class CarRentalImageViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; } = null!;

        // Evita o erro de conversão de string vazia para IFormFile
        [JsonIgnore]
        public IFormFile ImageUpload { get; set; } = null!;

        public string Image { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public string NameSupplier { get; set; } = null!;
    }
}