using Autofac;
using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Domain.Common.InterfaceDependency;
using Okala.Cryptocurrency.Infrastructure.DbContexts.Sql.SqlServer;
using Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap;
using System.Reflection;

namespace Okala.Cryptocurrency.Application.Registeration
{
    public static class AutofacConfigurationExtensions
    {
        #region NewConfiguration
        public class ServiceModules : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);

                #region Register AwsS3 Accessor
                builder.RegisterCoinMarketcap();
                #endregion

                #region Auto Assembly Registeration services with autofac and interface class
                Assembly ApiAssembly = typeof(Program).Assembly;
                Assembly EntitiesAssembly = typeof(IEntity).Assembly;
                Assembly DataAssembly = typeof(ApplicationDbContext).Assembly;

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<IScopedDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ITransientDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ISingletonDependency>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
                #endregion
                #endregion
            }
        }

        #region Accessors

        private static void RegisterCoinMarketcap(this ContainerBuilder builder)
        {

        }
        #endregion
    }
}
