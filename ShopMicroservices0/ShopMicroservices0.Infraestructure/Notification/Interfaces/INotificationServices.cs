using ShopMicroservices0.Infraestructure.Base;
using ShopMicroservices0.Infraestructure.Base;


namespace ShopMicroservices0.Infraestructure.Notification.Interfaces
{
    public interface INotificationServices<TModel> where TModel : class
    {
        public Task<NotificationResult> Send(TModel model);
    }
}

