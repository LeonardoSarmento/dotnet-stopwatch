
using System.Text.RegularExpressions;
partial class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("S = seconds => 10s = 10 seconds");
        Console.WriteLine("M = minutes => 1m = 1 minute");
        Console.WriteLine("0 = exit");
        Console.WriteLine("How long should the watch run for?");
        string input;
        char type;
        int time;
        Regex validPattern = MyRegex();

        do
        {
            input = Console.ReadLine().ToLower();

            if (validPattern.IsMatch(input))
            {
                if (input == "0")
                {
                    type = '0';
                    time = 0;
                }
                else
                {
                    type = char.Parse(input.Substring(input.Length - 1, 1));
                    time = int.Parse(input[..^1]);
                }

                // Console.WriteLine($"Valid input received. Char: {type}, Time: {time}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        } while (true);

        int multiplier = 1;

        if (type == 'm')
            multiplier = 60;

        if (time == 0)
            Exit();

        PreStart(time * multiplier);
    }

    private static void PreStart(int time)
    {
        Console.Clear();
        Console.WriteLine("Ready...");
        Thread.Sleep(1000);
        Console.WriteLine("Set...");
        Thread.Sleep(1000);
        Console.WriteLine("Go...");
        Thread.Sleep(1000);
        Start(time);
    }
    private static void Start(int time)
    {
        int currentTime = 0;

        while (currentTime != time)
        {
            Console.Clear();
            currentTime++;
            Console.WriteLine($"Stopwatch: {currentTime}");
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Stopwatch is done. Press any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }

    private static void Exit()
    {
        Console.WriteLine("Closing the stopwatch...");
        System.Environment.Exit(0);
    }

    [GeneratedRegex(@"^\d+[sm]$|^0$")]
    private static partial Regex MyRegex();
}
