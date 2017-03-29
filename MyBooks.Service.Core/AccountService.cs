using System.Collections.Generic;
using MyBooks.Model.Core.Interfaces;
using MyBooks.Model.Entities;
using MyBooks.Service.Core.Interfaces;

namespace MyBooks.Service.Core
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IList<Account> GetList()
        {
            return _accountRepository.GetList();
        }
    }
}
