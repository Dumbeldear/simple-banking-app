public class BankAccount
{
    // Declare variables
    public string Name { get; }
    public double Balance { get; private set; }

    // Bank Account constructor
    public BankAccount(string name, double initialBalance = 0)
    {
        Name = name;
        Balance = initialBalance;
    }

    public (bool success, string message) Deposit(double depositAmount)
    {

        if (depositAmount < 1)
        {
            return (false, "Deposit Amount has to be greater than zero.");
        }
        else
        {
            Balance += depositAmount;
            return (true, "You have succesfully deposited $" + depositAmount + " into your account.\n" +
                GetBalanceMessage());
        }
    }

    public (bool success, string message) Withdraw(double withdrawAmount)
    {

        if (withdrawAmount < 1)
        {
            return (false, "Withdraw Amount has to be greater than zero.");
        }
        else if (withdrawAmount > Balance)
        {
            return (false, "Withdraw Amount cannot be greater than your balance.\n" +
                GetBalanceMessage());
        }
        else
        {
            Balance -= withdrawAmount;
            return (true, "You have succesfully withdrew $" + withdrawAmount + " from your account.\n" +
                GetBalanceMessage());
        }
    }

    public string GetBalanceMessage()
    {
        return "Your current bank account balance is: $" + Balance;
    }
}