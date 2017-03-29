using MongoDB.Driver;
using MyBooks.Model.Entities;
using MyBooks.Model.Core.Interfaces;

namespace MyBooks.Model.Core
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IMongoDatabase mongodb) 
            : base(mongodb)
        {
        }
    }
}
