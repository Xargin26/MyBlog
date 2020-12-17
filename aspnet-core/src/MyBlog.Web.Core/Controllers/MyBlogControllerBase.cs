using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.Controllers
{
    public abstract class MyBlogControllerBase: AbpController
    {
        protected MyBlogControllerBase()
        {
            LocalizationSourceName = MyBlogConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
