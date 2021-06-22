using Autofac;
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
            // referenciar à camada de aplicacao
            builder.RegisterType<RepositoryFilme>().As<IRepositoryFilme>();
            builder.RegisterType<ServiceFilme>().As<IServiceFilme>();
        }
    }
}
