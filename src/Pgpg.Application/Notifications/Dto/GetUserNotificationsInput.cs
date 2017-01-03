using Abp.Notifications;
using Pgpg.Application.Dto;

namespace Pgpg.Application.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}