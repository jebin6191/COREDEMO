using System;
using System.Collections.Generic;
using System.Text;
using ZILDING_CORE.Models;

namespace ZILDING_CORE
{
    public interface IUnitOfWork
    {
        GenericRepository<Owner> Owner { get; }
        GenericRepository<Account> Account { get; }
        GenericRepository<User> User { get; }
        void Save();
    }
}
