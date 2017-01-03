using Microsoft.AspNetCore.Authentication.WeiBo;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public class WeiBoOptions : OAuthOptions
    {
        public WeiBoOptions()
        {
            AuthenticationScheme = WeiBoConsts.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-WeiBo";
            AuthorizationEndpoint = WeiBoConsts.AuthorizationEndpoint;
            TokenEndpoint = WeiBoConsts.TokenEndpoint;
            UserInformationEndpoint = WeiBoConsts.UserInformationEndpoint;
        }

        public bool IsMobile { get; set; }

        public string AppKey
        {
            get
            {
                return this.ClientId;
            }
            set
            {
                this.ClientId = value;
            }
        }

        public string AppSecret
        {
            get
            {
                return this.ClientSecret;
            }
            set
            {
                this.ClientSecret = value;
            }
        }
    }
}