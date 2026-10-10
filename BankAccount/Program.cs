using System;
using BankAccount.Interfaces;
using BankAccount.Services;
using BankAccount.Models;

IBankAccountService bankAccountService = new BankAccountService();
 
bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("Welcome to the Bank Account Management System!");
    Console.WriteLine("===============================================");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Create a new bank account");
    Console.WriteLine("2. View all bank accounts");
    Console.WriteLine("3. Deposit money into an account");
    Console.WriteLine("4. Withdraw money from an account");
    Console.WriteLine("5. Transfer money between accounts");
    Console.WriteLine("6. Exit");

    string choice = Console.ReadLine();


    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter account holder name: ");
                string name = Console.ReadLine();
                Console.Write("Enter initial balance: ");
                decimal initialBalance = decimal.TryParse(Console.ReadLine(), out decimal balance) ? balance : 0;
                var newAccount = bankAccountService.CreateAccount(name, initialBalance);
                Console.WriteLine($"Account created successfully! Account ID: {newAccount.Id}, Account Number: {newAccount.AccountNumber}");
                break;
            case "2":
                var accounts = bankAccountService.GetAllAccounts();
                if (accounts.Count == 0)
                {
                    Console.WriteLine("No accounts found.");
                }
                else
                {
                    foreach (var account in accounts)
                    {
                        Console.WriteLine(account);
                    }
                }
                break;
            case "3":
                Console.Write("Enter account ID to deposit into: ");
                int depositId = int.TryParse(Console.ReadLine(), out int id) ? id : 0;
                Console.Write("Enter amount to deposit: ");
                decimal depositAmount = decimal.TryParse(Console.ReadLine(), out decimal depositParsed) ? depositParsed : 0;
                bankAccountService.Deposit(depositId, depositAmount);
                Console.WriteLine("Deposit successful!");
                break;
            case "4":
                Console.Write("Enter account ID to withdraw from: ");
                int withdrawId = int.TryParse(Console.ReadLine(), out int wId) ? wId : 0;
                Console.Write("Enter amount to withdraw: ");
                decimal withdrawAmount = decimal.TryParse(Console.ReadLine(), out decimal withdrawParsed) ? withdrawParsed : 0;
                bankAccountService.Withdraw(withdrawId, withdrawAmount);
                Console.WriteLine("Withdrawal successful!");
                break;
            case "5":
                Console.Write("Enter source account ID: ");
                int sourceId = int.TryParse(Console.ReadLine(), out int sId) ? sId : 0;
                Console.Write("Enter destination account ID: ");
                int destinationId = int.TryParse(Console.ReadLine(), out int dId) ? dId : 0;
                Console.Write("Enter amount to transfer: ");
                decimal transferAmount = decimal.TryParse(Console.ReadLine(), out decimal transferParsed) ? transferParsed : 0;
                bankAccountService.Transfer(sourceId, destinationId, transferAmount);
                Console.WriteLine("Transfer successful!");
                break;
            case "6":
                isRunning = false;
                Console.WriteLine("Thank you for using the Bank Account Management System!");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}