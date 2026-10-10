# Bank Account Management System

A robust console-based banking application built with C# and .NET. The application implements core OOP principles, service abstraction via interfaces, input validation, defensive transaction handling, and file-based data persistence.

---

## Features

- **Account Lifecycle Management**: Create unique bank accounts with auto-incrementing ID tracking.
- **Transactional Operations**: Support for deposits, withdrawals, and account-to-account fund transfers.
- **Defensive Business Logic**:
  - Validation against negative deposits, withdrawals, or initial balances.
  - Insufficient fund checks prior to state mutation.
  - Atomic transfer validation (prevents self-transfer and guarantees rollback/state preservation on failure).
- **File Persistence**: Automatic serialization/deserialization to `accounts.txt` using delimited records (`Id|OwnerName|Balance`).
- **Interactive CLI**: Menu-driven interface protected with `TryParse` guards to prevent runtime format crashes.

---

## Project Structure

```text
BankAccount/
├── Models/
│   └── BankAccount.cs           # Encapsulated account entity and domain rules
├── Interfaces/
│   └── IBankAccountService.cs   # Service contract abstraction
├── Services/
│   └── BankAccountService.cs    # Core business logic and file I/O operations
├── accounts.txt                 # Persistent data store (pipe-delimited)
└── Program.cs                   # CLI menu, user input parsing, and global error handling
