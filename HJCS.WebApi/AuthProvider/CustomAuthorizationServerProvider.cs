using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.AdapterExternalServices;
using HJCS.Infrastructure.Repositories;
using Microsoft.Owin.Security.OAuth;

namespace HJCS.WebApi.AuthProvider
{
    public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var clientRepository = new ClientRepository(new ClientMappper(), new ClientsDataRetriever());

            var user =
                clientRepository.All.FirstOrDefault(t => t.Name == context.UserName && t.EMail == context.Password);

            if (user == default(Client))
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToLower()));
            identity.AddClaim(new Claim("username", user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            context.Validated(identity);
        }
    }
}
