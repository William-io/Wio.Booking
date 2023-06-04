using Wio.Booking.Business.Interfaces;

namespace Wio.Booking.Business.Notifications;

public class Notifier : INotifier
{
    public List<Notification> _notifications = null!;

    public Notifier() => _notifications = new List<Notification>();

    public List<Notification> GetNotifications() => _notifications;
    
    public void Handle(Notification notificacao)
    {
        _notifications.Add(notificacao);
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }
}