using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Model.Entities;

namespace MyBooks.Service.Core.Interfaces
{
    public interface IAccountService
    {
        IList<Account> GetList();
    }
}
