using BankAccount.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BankAccount.Models;
using System.IO;
using System.Text.Json;

namespace BankAccount.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly List<BankAccount1> _accounts = new List<BankAccount1>();
        public BankAccount1 CreateAccount(string accountHolderName, decimal initialBalance)
        {
            var account = new BankAccount1(accountHolderName, initialBalance);
            _accounts.Add(account);
            SaveToFile();               
            return account;
        }
        public List<BankAccount1> GetAllAccounts()
        {
            return _accounts;
        }
        public BankAccount1 GetAccountById(int accountId)
        {
            return _accounts.Find(a => a.Id == accountId);
        }
        public void Deposit(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null)
                throw new ArgumentException("Account not found.");
            account.Deposit(amount);
        }
        public void Withdraw(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null)
                throw new ArgumentException("Account not found.");
            account.Withdraw(amount);
        }
        public void Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = GetAccountById(fromAccountId);
            var toAccount = GetAccountById(toAccountId);
            if (fromAccount == null || toAccount == null)
                throw new ArgumentException("One or both accounts not found.");
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

        }

        // Added SaveToFile to resolve CS0103
        private void SaveToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_accounts, options);
            File.WriteAllText("accounts.json", json);
        }
    }
}
