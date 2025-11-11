public class BankAccount
{
    // Declare variables
    public int Id { get; }
    protected int Passcode { get; }
    public string Name { get; }
    protected decimal Balance { get; set; }
    public virtual string AccountType { get; }

    // Bank Account constructor
    public BankAccount(int id, string name, int passcode, decimal initialBalance = 0)
    {
        Id = id;
        Passcode = passcode;
        Name = name;
        Balance = initialBalance;
        AccountType = "Generic Bank Account";
    }

    public virtual (bool success, string message) Deposit(decimal depositAmount)
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

    public virtual (bool success, string message) Withdraw(decimal withdrawAmount)
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

    public decimal GetBalance()
    {
        return Balance;
    }

    public bool ValidatePasscode(int userInputtedPasscode)
    {
        return (userInputtedPasscode == Passcode);
    }
}

public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; }
    public override string AccountType { get; } = "Savings Account";

    public SavingsAccount(int id, string name, int passcode, decimal initialBalance = 0, decimal interestRate = (decimal)0.04)
        : base(id, name, passcode, initialBalance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        if (Balance > 0)
        {
            Balance += Balance * InterestRate;
        }
    }

    // Assume interest rate gain hits bank account every deposit - wish this happened in real life
    public override (bool success, string message) Deposit(decimal depositAmount)
    {

        if (depositAmount < 1)
        {
            return (false, "Deposit Amount has to be greater than zero.");
        }
        else
        {
            decimal InterestGain = Balance * InterestRate;
            Balance += depositAmount + InterestGain;
            return (true, "You have succesfully deposited $" + depositAmount + " into your account.\n" +
                "An interest gain of $" + InterestGain + " has occured since your last deposit.\n" +
                GetBalanceMessage());
        }
    }
}

public class CheckingsAccount : BankAccount
{
    public decimal TransactionFee { get; }
    public override string AccountType { get; } = "Checking Account";

    public CheckingsAccount(int id, string name, int passcode, decimal transactionFee = 2, decimal initialBalance = 0)
        : base(id, name, passcode, initialBalance)
    {
        TransactionFee = transactionFee;
    }

    public override (bool success, string message) Withdraw(decimal withdrawAmount)
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
            Balance -= withdrawAmount + TransactionFee;
            return (true, "You have succesfully withdrew $" + withdrawAmount + " from your account.\n" +
                "Your checking account has a transaction fee of $" + TransactionFee + "\n" + 
                GetBalanceMessage());
        }
    }
}