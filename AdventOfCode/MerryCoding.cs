public class MerryCoding
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText(@"/Users/renzo/Advent of Code/AdventOfCode/Input.txt");

        // Console.WriteLine(input);

        // Day1.CountFloors(input);
        // Day2.WrapingPaper(input);
        Day3.SantaDuo(input);
    }
}