using MongoDB.Driver;
using MyBooks.Model.Core.Interfaces;
using MyBooks.Model.Entities;

namespace MyBooks.Model.Core
{
    public class CredentialRepository : RepositoryBase<CredentialLogOn>, ICredentialRepository
    {
        public CredentialRepository(IMongoDatabase mongodb) 
            : base(mongodb)
        {
        }
    }
}
