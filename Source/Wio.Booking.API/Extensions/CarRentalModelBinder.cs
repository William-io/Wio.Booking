using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using Wio.Booking.API.ViewModels;

namespace Wio.Booking.API.Extensions;

public class CarRentalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)     
            throw new ArgumentNullException(nameof(bindingContext));
        

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true
        };

        var produtoImagemViewModel = JsonSerializer
            .Deserialize<CarRentalImageViewModel>(bindingContext.ValueProvider
            .GetValue("produto")
            .FirstOrDefault(), serializeOptions);

             produtoImagemViewModel.ImageUpload = bindingContext.ActionContext.HttpContext.Request.Form.Files
            .FirstOrDefault();

        bindingContext.Result = ModelBindingResult.Success(produtoImagemViewModel);
        return Task.CompletedTask;
    }
}
