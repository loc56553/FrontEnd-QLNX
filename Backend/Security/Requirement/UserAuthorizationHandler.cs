using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QuanLyNhaXe.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Security.Requirement
{
    public class UserAuthorizationHandler : IAuthorizationHandler
    {
        private readonly UserManager<UserIdentity> _userManager;
        public UserAuthorizationHandler(UserManager<UserIdentity> userManager)
        {
            _userManager = userManager;
        }
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var requirements = context.PendingRequirements.ToList();
            if (context.User == null)
                context.Fail();
            foreach (var requirement in requirements)
            {
                if (requirement is UserAuthorize1)
                {
                    if (User1(context.User, (UserAuthorize1)requirement))
                        context.Succeed(requirement);
                }
                if (requirement is UserAuthorize2)
                {
                    if (User2(context.User, (UserAuthorize2)requirement))
                        context.Succeed(requirement);
                }
                if (requirement is UserAuthorize3)
                {
                    if (User3(context.User, (UserAuthorize3)requirement))
                        context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }

        private bool User3(ClaimsPrincipal user, UserAuthorize3 requirement)
        {
            if (user == null)
                return false;
            var resul = user.FindFirstValue("UserName");
            var TaskappUser = _userManager.FindByNameAsync(resul);
            Task.WaitAll(TaskappUser);
            var appUser = TaskappUser.Result;
            if (appUser == null)
                return false;
            if (appUser.MucDoTruyCap != requirement.MucDoTruyCap)
                return false;
            return true;
        }

        private bool User2(ClaimsPrincipal user, UserAuthorize2 requirement)
        {
            if (user == null)
                return false;
            var resul = user.FindFirstValue("UserName");
            if (resul != null)
                return false;
            var TaskappUser = _userManager.FindByNameAsync(resul);
            Task.WaitAll(TaskappUser);
            var appUser = TaskappUser.Result;
            if (appUser == null)
                return false;
            if (appUser.MucDoTruyCap != requirement.MucDoTruyCap)
                return false;

            return true;
        }

        private bool User1(ClaimsPrincipal user, UserAuthorize1 requirement)
        {
            if (user == null)
                return false;
            var resul = user.FindFirstValue("UserName");
            if (resul == null)
                return false;
            var TaskappUser = _userManager.FindByNameAsync(resul);
            Task.WaitAll(TaskappUser);
            var appUser = TaskappUser.Result;
            if (appUser == null)
                return false;
            if (appUser.MucDoTruyCap != requirement.MucDoTruyCap)
                return false;
            return true;
        }
    }
}
