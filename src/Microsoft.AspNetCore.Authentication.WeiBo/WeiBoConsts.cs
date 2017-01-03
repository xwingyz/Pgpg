namespace Microsoft.AspNetCore.Authentication.WeiBo
{
    public class WeiBoConsts
    {
        public const string AuthenticationScheme = "WeiBo";

        public const string AuthorizationEndpoint = "https://api.weibo.com/oauth2/authorize";

        public const string TokenEndpoint = "https://api.weibo.com/oauth2/access_toke";

        public const string UserInformationEndpoint = "https://api.weibo.com/2/users/show.json";
    }
}