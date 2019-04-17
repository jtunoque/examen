using App.Domain.Services.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthCare.WebServices.Rest.Security
{
    public class SecurityProvider : OAuthAuthorizationServerProvider
    {
        readonly ISeguridadService seguridadService;

        public SecurityProvider(ISeguridadService seguridadService)
        {
            this.seguridadService = seguridadService;
        }
        
        //public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        //{
        //    string typeUser = "";// CommonFunctions.GetClaimFromAuthResponse(context, "typeUser");

        //    context.AdditionalResponseParameters.Add(new KeyValuePair<string, object>("typeUser", typeUser));

        //    return base.TokenEndpointResponse(context);
        //}

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => { context.Validated(); });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                var user = seguridadService.VerificarUsuario(context.UserName, context.Password);
              
                if (user == null)
                {
                    context.SetError("Usuario o contraseña incorrecta.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("usuarioID", user.UsuarioID.ToString()));
                identity.AddClaim(new Claim("nombres", $"{user.Nombres} {user.Apellidos}" ));

                context.Validated(identity);
            });
        }
    }
}