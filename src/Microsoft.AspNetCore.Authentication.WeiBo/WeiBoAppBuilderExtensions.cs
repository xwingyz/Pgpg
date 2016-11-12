using System;
using Microsoft.AspNetCore.Authentication.WeiBo;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add WeiBo authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class WeiBoAppBuilderExtensions
    {
        public static IApplicationBuilder UseWeiBoAuthentication(this IApplicationBuilder app, WeiBoOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<WeiBoMiddleware>(options);
        }

        public static IApplicationBuilder UseWeiBoAuthentication(this IApplicationBuilder app, Action<WeiBoOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new WeiBoOptions();
            configureOptions?.Invoke(options);

            return app.UseWeiBoAuthentication(options);
        }
    }
}
