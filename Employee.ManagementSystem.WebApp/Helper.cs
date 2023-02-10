using Radzen;

namespace Employee.ManagementSystem.WebApp;

public static class Helper
{
    public static void ShowNotification(string title, string body, NotificationSeverity severity, NotificationService notificationService)
    {
        NotificationMessage _notificationMessage = new NotificationMessage
        {
            Style = "position: absolute; left: -320px; top: -100px", 
            Severity = severity, 
            Summary = title, 
            Detail = body, 
            Duration = 6000
        };
        notificationService.Notify(_notificationMessage);
    }
}