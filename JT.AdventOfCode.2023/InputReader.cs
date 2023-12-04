namespace JT.AdventOfCode._2023;

public abstract class InputReader
{
    private static readonly string FilePath = $"{Directory.GetCurrentDirectory()}";

    protected static string[] InputByLine(string day, string fileName = "input.txt")
    {
        return File.ReadAllLines($"{FilePath}/{day}/resources/{fileName}");
    }
}