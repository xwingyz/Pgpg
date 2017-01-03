using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.WeiBo
{
    public class WeiBoHandler : OAuthHandler<WeiBoOptions>
    {

        public WeiBoHandler(HttpClient backchannel) : base(backchannel)
        {
        }
        protected override string FormatScope()
        {
            return string.Join(",", Options.Scope);
        }

        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var url = base.BuildChallengeUrl(properties, redirectUri);
            if (Options.IsMobile) url += "&display=mobile";
            return url;
        }

        protected override async Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        {
            var query = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", Options.ClientId },
                { "redirect_uri", redirectUri },
                { "client_secret", Options.ClientSecret},
                { "code", code},
                { "grant_type","authorization_code"}
            });
            var message = new HttpRequestMessage(HttpMethod.Post, Options.TokenEndpoint)
            {
                Content = query
            };
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Backchannel.SendAsync(message, Context.RequestAborted);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            result = "{\"" + result.Replace("=", "\":\"").Replace("&", "\",\"") + "\"}";
            return OAuthTokenResponse.Success(JObject.Parse(result));
        }


        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            string id = WeiBoHelper.GetId(tokens.Response);
            if (!string.IsNullOrEmpty(id))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", id,
                    "http://www.w3.org/2001/XMLSchema#string", this.Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:wechat:id", id, "http://www.w3.org/2001/XMLSchema#string",
                    this.Options.ClaimsIssuer));
            }
            HttpResponseMessage async =
                await this.Backchannel.GetAsync(this.Options.UserInformationEndpoint + (object)new QueryBuilder()
                                                {
                                                    {
                                                        "access_token",
                                                        tokens.AccessToken
                                                    },
                                                    {
                                                        "uid",
                                                        id
                                                    }
                                                }, this.Context.RequestAborted);
            async.EnsureSuccessStatusCode();
            JObject jobject = JObject.Parse(await async.Content.ReadAsStringAsync());

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties,
                Options.AuthenticationScheme);

            var notification = new OAuthCreatingTicketContext(ticket, this.Context,
                this.Options, this.Backchannel, tokens, jobject);
            string name = WeiBoHelper.GetName(jobject);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", name,
                    "http://www.w3.org/2001/XMLSchema#string", this.Options.ClaimsIssuer));
                identity.AddClaim(new Claim("urn:weibo:name", name, "http://www.w3.org/2001/XMLSchema#string",
                    this.Options.ClaimsIssuer));
            }
            string headImage = WeiBoHelper.GetHeadImage(jobject);
            if (!string.IsNullOrEmpty(headImage))
                identity.AddClaim(new Claim("urn:weibo:headimgurl", headImage,
                    "http://www.w3.org/2001/XMLSchema#string", this.Options.ClaimsIssuer));
            await this.Options.Events.CreatingTicket(notification);
            return notification.Ticket;
        }
    }
}