using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyBlog.Configuration;
using MyBlog.EntityFrameworkCore;
using MyBlog.Migrator.DependencyInjection;
using System;
using System.Runtime.InteropServices;

namespace MyBlog.Migrator
{
    [DependsOn(typeof(MyBlogEntityFrameworkModule))]
    public class MyBlogMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyBlogMigratorModule(MyBlogEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MyBlogMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = Environment.GetEnvironmentVariable(
                _appConfiguration.GetConnectionString(
                    MyBlogConsts.ConnectionStringName
                )
                , RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? EnvironmentVariableTarget.Machine : EnvironmentVariableTarget.Process
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyBlogMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
