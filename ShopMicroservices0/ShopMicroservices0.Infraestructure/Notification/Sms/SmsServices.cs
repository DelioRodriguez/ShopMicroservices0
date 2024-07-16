
using ShopMicroservices0.Infraestructure.Base;
using ShopMicroservices0.Infraestructure.Notification.Interfaces;
using ShopMicroservices0.Infraestructure.Notification.Models;

namespace ShopMicroservices0.Infraestructure.Notification.Sms
{
    public class SmsServices : INotificationServices<SmsModel>
    {
        public Task<NotificationResult> Send(SmsModel model)
        {
            throw new NotImplementedException();
        }
    }
}
