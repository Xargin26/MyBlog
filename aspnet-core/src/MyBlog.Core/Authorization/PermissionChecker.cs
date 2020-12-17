using Abp.Authorization;
using MyBlog.Authorization.Roles;
using MyBlog.Authorization.Users;

namespace MyBlog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
