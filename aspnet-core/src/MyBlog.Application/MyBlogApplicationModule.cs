using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyBlog.Authorization;

namespace MyBlog
{
    [DependsOn(
        typeof(MyBlogCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyBlogApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyBlogAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyBlogApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
