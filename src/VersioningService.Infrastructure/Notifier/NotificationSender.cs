using System;
using VersioningService.Core.Interfaces;

namespace VersioningService.Infrastructure.Notifier
{
    public class NotificationSender
    {
        private INotifier notifier;
        public NotificationSender(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public void Invoke()
        {
            // notifier.Notify()
        }
    }
}
