using System;
using VersioningService.Core.Interfaces;
using VersioningService.Core.Models;

namespace VersioningService.Infrastructure.Notifier
{
    public class SlackNotifier: INotifier
    {
        public SlackNotifier()
        {
        }

        public void Notify(NotificationText text, NotificationType action)
        {
            throw new NotImplementedException();
        }
    }
}
