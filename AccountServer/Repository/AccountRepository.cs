﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext)
        :base(repositoryContext)
    {
        
    }
    
    public IEnumerable<Account> GetAllAccounts()
    {
        return FindAll()
            .OrderBy(ac => ac.DateCreated);
    }
    public void CreateAccount(Account account)
    {
        account.Id = Guid.NewGuid();
        Create(account);
        Save();
    }
}