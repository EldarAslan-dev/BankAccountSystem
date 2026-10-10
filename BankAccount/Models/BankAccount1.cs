using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class BankAccount1
    {
        private static int _nextId { get; set; } = 1;
        public int Id { get; private set; }
        public string AccountNumber { get; private set; } = " ";
        public string AccountHolderName { get; private set; } = "John Doe";
        public decimal Balance { get; private set; } = 0.0m;
        public BankAccount1(string accountHolderName, decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }
            if (string.IsNullOrWhiteSpace(accountHolderName))
            {
                throw new ArgumentException("Account holder name cannot be empty.");

            }

            if (accountHolderName.Length > 100)
            {
                throw new ArgumentException("Account holder name cannot exceed 100 characters.");
            }
            if (accountHolderName.Contains('|'))
                throw new ArgumentException("Ad daxilində '|' işarəsi ola bilməz.");
            if (accountHolderName.Length < 2)
            {
                throw new ArgumentException("Account holder name must be at least 2 characters long.");
            }
            Id = _nextId++;
            AccountHolderName = accountHolderName.Trim();
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Account Holder: {AccountHolderName}, Balance: {Balance:C}";
        }

        public BankAccount1(int id, string accountHolderName, decimal balance)
        {
            Id = id;
            AccountHolderName = accountHolderName.Trim();
            Balance = balance;

        }
        public static void SetNextId(int nextId)
        {
            _nextId = nextId;
        }
    } 
}
