using Abp.Notifications;
using Pgpg.Dto;

namespace Pgpg.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}