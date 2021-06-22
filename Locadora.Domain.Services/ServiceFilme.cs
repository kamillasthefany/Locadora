using Locadora.Domain.Core.Interfaces.Repositories;
using Locadora.Domain.Core.Interfaces.Services;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Services
{
    public class ServiceFilme : ServiceBase<Filme>, IServiceFilme
    {
        private readonly IRepositoryFilme repositoryFilme;

        public ServiceFilme(IRepositoryFilme _repositoryFilme) : base(_repositoryFilme)
        {
            repositoryFilme = _repositoryFilme;
        }
    }
}
