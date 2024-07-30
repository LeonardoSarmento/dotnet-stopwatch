
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new();
        stopwatch.Menu();
    }
}
partial class Stopwatch
{
    public string? Data;
    public char Type;
    public int Time;
    public int Multiplier = 1;
    public readonly Regex validPattern = MyRegex();

    [GeneratedRegex(@"^\d+[sm]$|^0$")]
    private static partial Regex MyRegex();
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("S = seconds => 10s = 10 seconds");
        Console.WriteLine("M = minutes => 1m = 1 minute");
        Console.WriteLine("0 = exit");
        Console.WriteLine("How long should the watch run for?");

        AskForValue();

        if (Type == 'm')
            Multiplier = 60;

        if (Time == 0)
            Exit();

        PreStart(Time * Multiplier);
    }
    public void AskForValue()
    {
        Console.WriteLine("-----------------------------------------");
        do
        {
            Data = Console.ReadLine().ToLower();
            if (validPattern.IsMatch(Data))
            {
                if (Data == "0")
                {
                    Type = '0';
                    Time = 0;
                }
                else
                {
                    Type = char.Parse(Data.Substring(Data.Length - 1, 1));
                    Time = int.Parse(Data[..^1]);
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        } while (true);
        Console.WriteLine("");
    }
    private void PreStart(int time)
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
    private void Start(int time)
    {
        int currentTime = 0;

        while (currentTime != time)
        {
            Console.Clear();
            currentTime++;
            Console.WriteLine($"Stopwatch: {currentTime} s");
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
}