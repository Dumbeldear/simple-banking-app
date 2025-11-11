# SimpleBankingApp

A simple command-line banking application written in C# to demonstrate practical use of **Object-Oriented Programming (OOP)** principles.  
The program allows users to create accounts, log in, deposit or withdraw funds, check balances, and apply recursive interest on savings accounts.

---

## Overview

This project was built as a learning exercise to reinforce core computer science and software engineering fundamentals in C#.  
It focuses on OOP design, clean class structure, and good encapsulation practices while maintaining a minimal user interface.

---

## Key Features

- **Account Creation and Management**  
  Create Generic, Savings, or Checking accounts.  
  Each account type behaves differently through inheritance and method overriding.

- **Savings Account Interest**  
  Apply compound interest recursively a specified number of times.

- **Factory Pattern Implementation**  
  Uses an `AccountFactory` class to handle account creation, improving modularity and scalability.

- **Encapsulation and Data Protection**  
  Internal fields such as `Balance` and `Passcode` are protected, with access restricted to validated methods.

- **Interactive CLI Menu**  
  A structured menu guides the user through available banking operations and validates input.

---

## Object-Oriented Design Concepts

| Concept | Implementation |
|----------|----------------|
| **Encapsulation** | Sensitive data (`Balance`, `Passcode`) are protected and modified only through methods. |
| **Inheritance** | `SavingsAccount` and `CheckingsAccount` extend a shared `BankAccount` base class. |
| **Polymorphism** | Overridden `Deposit()` and `Withdraw()` methods customize behavior for each account type. |
| **Abstraction** | `BankSystem` separates logic from presentation; `Menu` handles user interaction. |
| **Factory Pattern** | `AccountFactory` abstracts the creation of account objects. |

---

## Project Structure

~~~text
SimpleBankingApp/
├── AccountFactory.cs      # Factory class for creating account instances
├── BankAccount.cs         # Base and derived account classes
├── BankSystem.cs          # Core application logic and menu orchestration
├── Menu.cs                # CLI user interface and input handling
├── MenuOption.cs          # Menu option model
└── Program.cs             # Entry point of the application
~~~

---

## Getting Started

### Prerequisites
- .NET SDK 9.0 or later

### Running the Application

~~~bash
# Clone the repository
git clone https://github.com/your-username/SimpleBankingApp.git
cd SimpleBankingApp

# Run the application
dotnet run
~~~

---

## Example Interaction

~~~text
You are currently not logged in.
1: Create Account
2: Log In
3: Exit
Please select an option: 1

Enter account name: Kevin
Create a four digit passcode: 1234
Account with id '1' and name 'Kevin' created with balance: $0.00
~~~

---

## Future Enhancements

- Add persistent data storage (e.g., JSON or database)
- Implement transaction history tracking
- Add unit tests using xUnit
- Encrypt or hash stored passcodes
- Introduce additional account types (e.g., Business, Student)
- Improve console formatting and error handling

---

## Technologies Used

- **Language:** C#  
- **Framework:** .NET 9  
- **Paradigm:** Object-Oriented Programming  
- **Pattern:** Factory Pattern  

---

## What I Learned

- Reinforced core OOP principles in a practical scenario  
- Designed class hierarchies using inheritance and polymorphism  
- Implemented a simple Factory Pattern for object creation  
- Gained experience with input validation and CLI user interfaces  
- Practiced writing maintainable and extensible C# code
