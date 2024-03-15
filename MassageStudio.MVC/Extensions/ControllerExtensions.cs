using MassageStudio.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MassageStudio.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string type, string message)
        {
            var notificiation = new Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notificiation);
        }
    }
}
