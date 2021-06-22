using Autofac;
using Locadora.Application;
using Locadora.Application.Interfaces;
using Locadora.Application.Interfaces.Mapper;
using Locadora.Application.Mapper;
using Locadora.Domain.Core.Interfaces.Repositories;
using Locadora.Domain.Core.Interfaces.Services;
using Locadora.Domain.Services;
using Locadora.Infra.Data.Repositories;

namespace Locadora.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceFilme>().As<IApplicationServiceFilme>();
            builder.RegisterType<ServiceFilme>().As<IServiceFilme>();
            builder.RegisterType<RepositoryFilme>().As<IRepositoryFilme>();
            builder.RegisterType<ServiceFilme>().As<IServiceFilme>();
            builder.RegisterType<MapperFilme>().As<IMapperFilme>();
        }
    }
}
