using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using BankAccount.Models;
using BankAccount.Services;

namespace BankAccount.Interfaces
{
    public interface IBankAccountService
    {
        BankAccount1 CreateAccount(string accountHolderName, decimal initialBalance);
        List<BankAccount1> GetAllAccounts();
        BankAccount1 GetAccountById(int accountId);
        void Deposit(int accountId, decimal amount);
        void Withdraw(int accountId, decimal amount);
        void Transfer(int fromAccountId, int toAccountId, decimal amount);

    }
}
