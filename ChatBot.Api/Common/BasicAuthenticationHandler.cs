using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChatBot.Api.Common
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AppSettings _settings;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, AppSettings settings) : base(options, logger, encoder, clock)
        {
            _settings = settings;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing."));
            string apiKey = Request.Headers["authorization"];
            return Task.FromResult(!apiKey.Equals(_settings.AiApiKey)
                ? AuthenticateResult.Fail("Api key is not correct")
                : AuthenticateResult.Success(
                    new AuthenticationTicket(new GenericPrincipal(new GenericIdentity("Admin"), null), "Default")));
        }
    }
}