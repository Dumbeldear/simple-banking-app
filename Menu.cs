public class Menu
{
    // Define menu options
    private readonly List<MenuOption> _menuOptions = new()
    {
        new MenuOption(1, "Create Account", requiresNoLogin: true),
        new MenuOption(2, "Log In", requiresNoLogin: true),
        new MenuOption(3, "Deposit", requiresLogin: true),
        new MenuOption(4, "Withdraw", requiresLogin: true),
        new MenuOption(5, "Check Balance", requiresLogin: true),
        new MenuOption(6, "Log Out", requiresLogin: true),
        new MenuOption(7, "Exit")
    };

    // Display and return menu options
    public int Show(bool isLoggedIn, string? accountName = null)
    {
        Console.WriteLine(isLoggedIn ? $"Welcome back, {accountName}!" : "You are currently not logged in.");

        var options = _menuOptions.Where(o =>
            (!o.RequiresLogin && !o.RequiresNoLogin) ||
            (o.RequiresLogin && isLoggedIn) ||
            (o.RequiresNoLogin && !isLoggedIn));
        foreach (var opt in options)
            Console.WriteLine($"{opt.Id}: {opt.Label}");

        return GetValidSelection(options.Select(o => o.Id).ToList());
    }

    // Generic get input method
    public string GetStringInput(string message)
    {
        bool validInput = false;
        string stringInput = "";

        while (!validInput)
        {
            Console.Write(message);
            stringInput = Console.ReadLine() ?? "";

            if (stringInput == string.Empty)
            {
                Console.WriteLine("Input cannot be empty.");
            }
            else
            {
                validInput = true;
            }
        }

        return stringInput;
    }

    public double GetDoubleInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid double value.");
            }
        }
    }

    public int GetIntInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value.");
            }
        }
    }

    public int GetPasscodeInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int number))
            {
                if (input.Length != 4)
                {
                    Console.WriteLine("Invalid input. Passcode must be four digits");
                }
                else
                {
                    return number;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value.");
            }
        }
    }

    // Validate numeric user inputs
    private int GetValidSelection(List<int> validIds)
    {
        while (true)
        {
            Console.Write("Please select an option: ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int choice) && validIds.Contains(choice))
                return choice;

            Console.WriteLine("Invalid input. Try again.");
        }
    }
}
