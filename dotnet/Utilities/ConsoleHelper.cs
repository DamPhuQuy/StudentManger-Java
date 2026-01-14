namespace StudentManagement.Utilities;

// Console UI Helper
public static class ConsoleHelper
{
    public static void PrintHeader(string title)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔" + new string('═', 78) + "╗");
        Console.WriteLine("║" + CenterText(title, 78) + "║");
        Console.WriteLine("╚" + new string('═', 78) + "╝");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void PrintSubHeader(string subtitle)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n" + new string('─', 80));
        Console.WriteLine(subtitle);
        Console.WriteLine(new string('─', 80));
        Console.ResetColor();
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✓ {message}");
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ {message}");
        Console.ResetColor();
    }

    public static void PrintWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠ {message}");
        Console.ResetColor();
    }

    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"ℹ {message}");
        Console.ResetColor();
    }

    public static string ReadInput(string prompt)
    {
        Console.Write($"{prompt}: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public static string ReadPassword(string prompt)
    {
        Console.Write($"{prompt}: ");
        var password = string.Empty;
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[0..^1];
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            var input = ReadInput(prompt);
            if (int.TryParse(input, out var value) && value >= min && value <= max)
                return value;

            PrintError($"Please enter a valid number between {min} and {max}");
        }
    }

    public static double ReadDouble(string prompt, double min = double.MinValue, double max = double.MaxValue)
    {
        while (true)
        {
            var input = ReadInput(prompt);
            if (double.TryParse(input, out var value) && value >= min && value <= max)
                return value;

            PrintError($"Please enter a valid number between {min} and {max}");
        }
    }

    public static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            var input = ReadInput($"{prompt} (dd/MM/yyyy)");
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                return date;

            PrintError("Please enter a valid date in format dd/MM/yyyy");
        }
    }

    public static bool Confirm(string message)
    {
        Console.Write($"{message} (y/n): ");
        var key = Console.ReadKey();
        Console.WriteLine();
        return key.Key == ConsoleKey.Y;
    }

    public static void WaitForKey(string message = "Press any key to continue...")
    {
        Console.WriteLine($"\n{message}");
        Console.ReadKey(true);
    }

    public static void PrintTable<T>(IEnumerable<T> items, params (string header, Func<T, string> getValue, int width)[] columns)
    {
        if (!items.Any())
        {
            PrintWarning("No data to display");
            return;
        }

        // Print header
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (var (header, _, width) in columns)
        {
            Console.Write(PadRight(header, width) + " ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('─', columns.Sum(c => c.width + 1)));
        Console.ResetColor();

        // Print rows
        foreach (var item in items)
        {
            foreach (var (_, getValue, width) in columns)
            {
                Console.Write(PadRight(getValue(item), width) + " ");
            }
            Console.WriteLine();
        }
    }

    private static string CenterText(string text, int width)
    {
        var padding = (width - text.Length) / 2;
        return new string(' ', padding) + text + new string(' ', width - text.Length - padding);
    }

    private static string PadRight(string text, int width)
    {
        if (text.Length > width)
            return text[..(width - 3)] + "...";
        return text.PadRight(width);
    }
}
