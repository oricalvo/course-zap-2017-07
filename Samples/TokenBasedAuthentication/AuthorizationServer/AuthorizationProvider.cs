using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
{
    public SimpleAuthorizationServerProvider()
    {
    }

    public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
    {
        return base.GrantClientCredentials(context);
    }

    public override Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
    {
        return base.GrantAuthorizationCode(context);
    }

    public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
    {
        return base.GrantCustomExtension(context);
    }

    public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
    {
        context.Validated();

        return Task.FromResult(0);
        //return base.ValidateAuthorizeRequest(context);
    }

    public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
    {
        if (context.ClientId == "client1")
        {
            context.Validated("http://localhost:62613/oauthcallback");
        }

        return Task.FromResult(0);

        //return base.ValidateClientRedirectUri(context);
    }

    public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
    {
        return base.ValidateTokenRequest(context);
    }

    public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
    {
        context.RequestCompleted();

        return Task.FromResult(0);
        //return base.AuthorizeEndpoint(context);
    }

    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
        context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        identity.AddClaim(new Claim("ori", context.UserName));
        identity.AddClaim(new Claim("role", "user"));

        context.Validated(identity);
    }
}

public class SimpleAuthorizationCodeProvider : IAuthenticationTokenProvider
{
    public void Create(AuthenticationTokenCreateContext context)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(AuthenticationTokenCreateContext context)
    {
        throw new NotImplementedException();
    }

    public void Receive(AuthenticationTokenReceiveContext context)
    {
        throw new NotImplementedException();
    }

    public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    {
        throw new NotImplementedException();
    }
}
