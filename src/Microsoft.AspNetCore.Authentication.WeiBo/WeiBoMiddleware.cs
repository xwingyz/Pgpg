using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Authentication.WeiBo
{
    public class WeiBoMiddleware : OAuthMiddleware<WeiBoOptions>
    {
        public WeiBoMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions,
            IOptions<WeiBoOptions> options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            if (sharedOptions == null)
            {
                throw new ArgumentNullException(nameof(sharedOptions));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(this.Options.AppKey))
                throw new ArgumentException("AppKey");

            if (string.IsNullOrWhiteSpace(this.Options.AppSecret))
                throw new ArgumentException("AppSecret");

            if (Options.Scope.Count == 0)
            {
                Options.Scope.Add("get_token_info");
            }
        }

        protected override AuthenticationHandler<WeiBoOptions> CreateHandler()
        {
            return new WeiBoHandler(Backchannel);
        }
    }

}