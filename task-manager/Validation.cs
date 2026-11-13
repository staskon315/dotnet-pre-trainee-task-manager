static class Validation
{
    public static int GetValidInputForNumber()
    {
        int choice;
        string? input = Console.ReadLine() ?? "";
        while (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid data entered. Please try again. ");
            input = Console.ReadLine() ?? "";
        }

        return choice;
    }

    public static string GetValidInputForString()
    {
        string? input = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid data entered. Please try again. ");
            input = Console.ReadLine() ?? "";
        }

        return input;
    }

    public static bool GetValidInputForBool()
    {
        Console.WriteLine("Select whether the task has been completed or not.");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        while (true)
        {
            string? input = Console.ReadLine() ?? "";
            if (input == "1") return true;
            if (input == "2") return false;
            Console.WriteLine("Invalid input. Please enter 1 (Yes) or 2 (No).");
        }
    }

}