using System;
using VersioningService.Core.Models;

namespace VersioningService.Core.Interfaces
{
    public interface INotifier
    {
        void Notify(NotificationText text, NotificationType action);
    }
}
