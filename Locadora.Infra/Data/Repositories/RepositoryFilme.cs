using Locadora.Domain.Core.Interfaces.Repositories;
using Locadora.Domain.Entities;

namespace Locadora.Infra.Data.Repositories
{
    public class RepositoryFilme : RepositoryBase<Filme>, IRepositoryFilme
    {
        private readonly LocadoraContext _locadoraContext;

        public RepositoryFilme(LocadoraContext locadoraContext) : base(locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }
    }
}
