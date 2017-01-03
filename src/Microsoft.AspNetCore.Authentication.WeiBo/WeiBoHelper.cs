using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.WeiBo
{
    public static class WeiBoHelper
    {
        internal static string GetId(JObject payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            return payload.Value<string>("uid");
        }

        internal static string GetName(JObject payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            return payload.Value<string>("screen_name");
        }

        internal static string GetHeadImage(JObject payload)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            return payload.Value<string>("profile_image_url");
        }
    }
}