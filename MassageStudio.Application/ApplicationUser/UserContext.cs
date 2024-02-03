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
        Task<CurrentUser?> GetCurrentUserAsync();
    }
    internal class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<Domain.Entities.ApplicationUser> signInManager;
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;

        public UserContext(IHttpContextAccessor httpContextAccessor, SignInManager<Domain.Entities.ApplicationUser> signInManager, UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<CurrentUser?> GetCurrentUserAsync()
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
            var name = "";
            var lastName = "";
            var userInManage = await userManager.FindByIdAsync(id);
            if (userInManage != null)
            {
                name = userInManage.Name;
                lastName = userInManage.LastName;
            }
            return new CurrentUser(id, email, name,lastName, roles);
        }
    }
}
