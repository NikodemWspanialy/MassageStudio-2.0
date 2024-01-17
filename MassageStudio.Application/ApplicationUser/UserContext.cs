using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
    internal class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            var id = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
            var name = user.FindFirst(x => x.Type == ClaimTypes.Name)!.Value;
            return new CurrentUser(id, email, name, roles);
        }
    }
}
