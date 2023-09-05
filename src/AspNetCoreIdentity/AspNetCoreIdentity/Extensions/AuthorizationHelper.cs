using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Extensions
{
    public class PermissaoNecessaria : IAuthorizationRequirement
    {
        public string Permissao { get;}
        public PermissaoNecessaria(string permissao)
        {
            Permissao = permissao;
        }

    }


    public class PermissaoNecessariaHandler : AuthorizationHandler<PermissaoNecessaria>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoNecessaria requesito)
        {
            if(context.User.HasClaim(c => c.Type == "Permissao" && c.Value.Contains(requesito.Permissao)))
            {
                context.Succeed(requesito);
            }

            return Task.CompletedTask;
        }
    }
}
