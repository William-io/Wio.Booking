using Wio.Booking.Business.Notifications;

namespace Wio.Booking.Business.Interfaces;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}