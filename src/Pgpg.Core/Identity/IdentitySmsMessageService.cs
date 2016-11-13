using System.Threading.Tasks;
using Abp.Dependency;
using Castle.Core.Logging;
using Microsoft.AspNet.Identity;
using Pgpg.Core.Smsing;

namespace Pgpg.Core.Identity
{
    public class IdentitySmsMessageService : IIdentityMessageService, ITransientDependency
    {
        private readonly ISmsSender _smsSender;
        public ILogger Logger { get; set; }

        public IdentitySmsMessageService(ISmsSender smsSender)
        {
            _smsSender = smsSender;
            Logger = NullLogger.Instance;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            await _smsSender.SendAsync(new SmsMessage(message.Destination, message.Body));
        }
    }
}
