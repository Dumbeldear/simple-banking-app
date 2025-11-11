public class BankSystem
{
    // Create menu
    private readonly Menu _menu = new Menu();
    // Create bank account
    private BankAccount? _account;

    // List of Bank Accounts
    private List<BankAccount> bankAccounts = new List<BankAccount>();
    // Bool to hold logged in/out state
    private bool isLoggedIn = false;

    // Run the menu system
    public void Run()
    {
        // Keep running the menu until user exits
        bool running = true;

        while (running)
        {
            string? currentUser = _account?.Name;
            int choice = _menu.Show(isLoggedIn, currentUser);

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    ValidateLogIn();
                    break;
                case 3:
                    if (!EnsureAccountExists()) break;
                    Deposit(_account!);
                    break;
                case 4:
                    if (!EnsureAccountExists()) break;
                    Withdraw(_account!);
                    break;
                case 5:
                    if (!EnsureAccountExists()) break;
                    CheckBalance(_account!);
                    break;
                case 6:
                    LogOut();
                    break;
                case 7:
                    ApplyInterest(_account!);
                    break;
                case 8:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Option not yet implemented.");
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        int accountTypeInt = _menu.ShowBankAccountOptions(isLoggedIn);
        AccountType accountType = (AccountType)accountTypeInt;

        string name = _menu.GetStringInput("Enter account name: ");
        int passcode = _menu.GetPasscodeInput("Create a four digit passcode: ");
        int nextBankId = GetNextBankAccountId();

        _account = AccountFactory.Create(accountType, nextBankId, name, passcode);

        Console.WriteLine($"Account with id '{_account!.Id}' and name '{_account!.Name}' created with balance: ${_account!.GetBalance()}");
        bankAccounts.Add(_account);
        LogIn();
    }

    private int GetNextBankAccountId()
    {
        int highestBankAccountId = 1;

        if (bankAccounts.Count < 1)
        {
            return highestBankAccountId;
        }
        else
        {
            foreach (BankAccount bankAccount in bankAccounts)
            {
                if (bankAccount.Id > highestBankAccountId)
                {
                    highestBankAccountId = bankAccount.Id;
                }
            }
        }
        return highestBankAccountId + 1;
    }

    private void ValidateLogIn()
    {
        int userInputBankAccountId = _menu.GetIntInput("Enter your bank account id: ");
        int userInputPasscode = _menu.GetPasscodeInput("Enter your bank account passcode: ");

        // check all accounts for correct combination
        foreach (BankAccount bankAccount in bankAccounts)
        {
            if (bankAccount.Id == userInputBankAccountId && bankAccount.ValidatePasscode(userInputPasscode))
            {
                _account = bankAccount;
                LogIn();
                Console.WriteLine($"You have successfully logged into account: '{bankAccount.Name}'");
            }
        }

        if (_account == null) 
        {
            Console.WriteLine("You entered invalid credentials.");
        }
    }

    private void LogIn()
    {
        isLoggedIn = true;
    }

    private void LogOut()
    {
        _account = null;
        isLoggedIn = false;
    }

    private bool EnsureAccountExists()
    {
        if (_account == null)
        {
            Console.WriteLine("Please create an account first.");
            return false;
        }
        return true;
    }
    
    private void ApplyInterest(BankAccount account)
    {
        if (account is SavingsAccount savingsAccount)
        {
            int n = _menu.GetIntInput("Enter the number of times you want interest to apply: ");
            Console.WriteLine(savingsAccount.ApplyInterestOverNTimes(n));
        }
    }

    private void Deposit(BankAccount account)
    {
        decimal despositAmount = _menu.GetDecimalInput("Enter the amount you wish to deposit: ");
        var despositResult = account.Deposit(despositAmount);
        Console.WriteLine(despositResult.message);
    }

    private void Withdraw(BankAccount account)
    {
        decimal withdrawAmount = _menu.GetDecimalInput("Enter the amount you wish to withdraw: ");
        var withdrawResult = account.Withdraw(withdrawAmount);
        Console.WriteLine(withdrawResult.message);
    }

    private void CheckBalance(BankAccount account)
    {
        Console.WriteLine(account.GetBalanceMessage());
    }
}