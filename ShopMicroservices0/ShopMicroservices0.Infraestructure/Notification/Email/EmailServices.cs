using ShopMicroservices0.Infraestructure.Base;
using ShopMicroservices0.Infraestructure.Notification.Interfaces;
using ShopMicroservices0.Infraestructure.Notification.Models;
using ShopMicroservices0.Infraestructure.Base;
using System.Collections.Generic;

namespace ShopMicroservices0.Infraestructure.Notification.Email
{
    public class EmailServices : INotificationServices<EmailModel>
    {
        public Task<NotificationResult> Send(EmailModel model)
        {
            throw new NotImplementedException();
        }
    }

}
