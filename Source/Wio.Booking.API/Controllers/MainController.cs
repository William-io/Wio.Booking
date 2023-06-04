using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Notifications;

namespace Wio.Booking.API.Controllers;


public abstract class MainController : Controller
{
    //private readonly INotifier _notifier;

    //protected MainController(INotifier notified)
    //{
    //    _notifier = notified;
    //}

    //protected bool OperacaoValida()
    //{
    //    return !_notifier.HasNotification();
    //}

    //protected ActionResult CustomResponse(object? result = null)
    //{
    //    if (OperacaoValida())
    //    {
    //        return Ok(new
    //        {
    //            success = true,
    //            data = result
    //        });
    //    }

    //    return BadRequest(new
    //    {
    //        success = false,
    //        errors = _notifier.GetNotifications().Select(n => n.Message)
    //    });
    //}

    //protected ActionResult CustomResponse(ModelStateDictionary modelState)
    //{
    //    if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
    //    return CustomResponse();
    //}

    //protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    //{
    //    var erros = modelState.Values.SelectMany(e => e.Errors);
    //    foreach (var erro in erros)
    //    {
    //        var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
    //        NotificarErro(errorMsg);
    //    }
    //}

    //protected void NotificarErro(string mensagem)
    //{
    //    _notifier.Handle(new Notification(mensagem));
    //}
}