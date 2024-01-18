using Entities.Models;

namespace Contracts;

public interface IAccountRepository
{
    IEnumerable<Account> GetAllAccounts();
    void CreateAccount(Account account);
}