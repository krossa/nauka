using System.Threading;
using System.Threading.Tasks;

namespace patterns.Cqs.Notifications
{
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
        Task HandleAsync(TNotification notification, CancellationToken cancellation = default);
    }
}