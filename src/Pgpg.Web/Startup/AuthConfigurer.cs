using System;
using System.Text;
using Microsoft.AspNet.Identity;
using Abp.Configuration;
using Abp.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Pgpg.Configuration;
using Pgpg.Web.Authentication.JwtBearer;
using Abp.Extensions;

namespace Pgpg.Web.Startup
{
    public static class AuthConfigurer
    {
        public const string AuthenticationScheme = "PgpgAuthSchema";

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="configuration">The configuration.</param>
        public static void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = AuthenticationScheme,
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Error/E403"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = false,
                AuthenticationScheme = DefaultAuthenticationTypes.TwoFactorCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
                CookieName = DefaultAuthenticationTypes.TwoFactorCookie
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = false,
                AuthenticationScheme = DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie,
                CookieName = DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie
            });

            if (bool.Parse(configuration["Authentication:OpenId:IsEnabled"]))
            {
                app.UseOpenIdConnectAuthentication(CreateOpenIdConnectAuthOptions(configuration));
            }

            if (bool.Parse(configuration["Authentication:Microsoft:IsEnabled"]))
            {
                app.UseMicrosoftAccountAuthentication(CreateMicrosoftAuthOptions(configuration));
            }

            if (bool.Parse(configuration["Authentication:Google:IsEnabled"]))
            {
                app.UseGoogleAuthentication(CreateGoogleAuthOptions(configuration));
            }

            if (bool.Parse(configuration["Authentication:Twitter:IsEnabled"]))
            {
                app.UseTwitterAuthentication(CreateTwitterAuthOptions(configuration));
            }

            if (bool.Parse(configuration["Authentication:Facebook:IsEnabled"]))
            {
                app.UseFacebookAuthentication(CreateFacebookAuthOptions(configuration));
            }

            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                ConfigureJwtBearerAuthentication(app, configuration);
            }
        }

        private static OpenIdConnectOptions CreateOpenIdConnectAuthOptions(IConfiguration configuration)
        {
            var settingManager = IocManager.Instance.Resolve<ISettingManager>();
            var websiteAddress = settingManager.GetSettingValue(AppSettings.General.WebSiteRootAddress);

            var options = new OpenIdConnectOptions
            {
                ClientId = configuration["Authentication:OpenId:ClientId"],
                Authority = configuration["Authentication:OpenId:Authority"],
                PostLogoutRedirectUri = websiteAddress + "Account/Logout",
                ResponseType = OpenIdConnectResponseType.IdToken,
                SignInScheme = AuthenticationScheme
            };

            var clientSecret = configuration["Authentication:OpenId:ClientSecret"];
            if (!clientSecret.IsNullOrEmpty())
            {
                options.ClientSecret = clientSecret;
            }

            return options;
        }

        private static MicrosoftAccountOptions CreateMicrosoftAuthOptions(IConfiguration configuration)
        {
            return new MicrosoftAccountOptions
            {
                SignInScheme = AuthenticationScheme,
                ClientId = configuration["Authentication:Microsoft:ClientId"],
                ClientSecret = configuration["Authentication:Microsoft:ClientSecret"]
            };
        }

        private static GoogleOptions CreateGoogleAuthOptions(IConfiguration configuration)
        {
            return new GoogleOptions
            {
                SignInScheme = AuthenticationScheme,
                ClientId = configuration["Authentication:Google:ClientId"],
                ClientSecret = configuration["Authentication:Google:ClientSecret"]
            };
        }

        private static TwitterOptions CreateTwitterAuthOptions(IConfiguration configuration)
        {
            return new TwitterOptions
            {
                SignInScheme = AuthenticationScheme,
                ConsumerKey = configuration["Authentication:Twitter:ConsumerKey"],
                ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"],
                RetrieveUserDetails = true
            };
        }

        private static FacebookOptions CreateFacebookAuthOptions(IConfiguration configuration)
        {
            var options = new FacebookOptions
            {
                AppId = configuration["Authentication:Facebook:AppId"],
                AppSecret = configuration["Authentication:Facebook:AppSecret"],
                SignInScheme = AuthenticationScheme
            };

            options.Scope.Add("email");
            options.Scope.Add("public_profile");

            return options;
        }

        private static void ConfigureJwtBearerAuthentication(IApplicationBuilder app, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"]));

            //Adding bearer authentication
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,

                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                    // Validate the token expiry
                    ValidateLifetime = true,

                    // If you want to allow a certain amount of clock drift, set that here
                    ClockSkew = TimeSpan.Zero
                }
            });

            // Adding JWT generation endpoint
            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(new TokenProviderOptions
            {
                Path = "/jwt-token/authenticate",
                Issuer = configuration["Authentication:JwtBearer:Issuer"],
                Audience = configuration["Authentication:JwtBearer:Audience"],
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                Expiration = TimeSpan.FromDays(1)
            }));
        }
    }
}
