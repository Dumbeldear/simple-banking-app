public class BankSystem
{
    // Create menu
    private readonly Menu _menu = new Menu();
    // Create bank account
    private BankAccount? _account;

    // Run the menu system
    public void Run()
    {
        // Keep running the menu until user exits
        bool running = true;

        while (running)
        {
            bool isLoggedIn = _account != null;
            string? currentUser = _account?.Name;
            int choice = _menu.Show(isLoggedIn, currentUser);

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    if (!EnsureAccountExists()) break;
                    Deposit(_account!);
                    break;
                case 3:
                    if (!EnsureAccountExists()) break;
                    Withdraw(_account!);
                    break;
                case 5:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Option not yet implemented.");
                    break;
            }
        }
    }

    // Create bank account
    private void CreateAccount()
    {
        string name = _menu.GetStringInput("Enter account name: ");
        _account = new BankAccount(name);
        Console.WriteLine($"Account '{_account.Name}' created with balance: ${_account.Balance}");
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

    private void Deposit(BankAccount account)
    {
        double despositAmount = _menu.GetDoubleInput("Enter the amount you wish to deposit: ");
        var despositResult = account.Deposit(despositAmount);
        Console.WriteLine(despositResult.message);
    }

    private void Withdraw(BankAccount account)
    {
        double withdrawAmount = _menu.GetDoubleInput("Enter the amount you wish to withdraw: ");
        var withdrawResult = account.Withdraw(withdrawAmount);
        Console.WriteLine(withdrawResult.message);
    }
}