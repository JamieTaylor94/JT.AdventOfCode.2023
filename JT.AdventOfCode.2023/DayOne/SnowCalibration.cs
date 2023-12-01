using System.Text.RegularExpressions;

namespace JT.AdventOfCode._2023.DayOne;

public record CalibrationResult(string First, string Last);

public class SnowCalibration
{
    private readonly Dictionary<string, string > _writtenNumbersToDigit = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
    };
    
    public int Calculate(IEnumerable<string> lines)
    {
        return lines.Select(line =>
        {
            var numbers = string.Concat(line.Where(char.IsDigit));
            return int.Parse($"{numbers.First()}{numbers.Last()}");
        }).Sum();
    }
    
    public int CalculateWithWrittenNumbers(IEnumerable<string> lines)
    {
        return lines.Select(line =>
        {
            var result = FindFirstAndLastNumbers(line);
            
            var firstNumber = ReplaceWrittenNumberWithDigit(result.First);
            var secondNumber = ReplaceWrittenNumberWithDigit(result.Last);

            return int.Parse($"{firstNumber}{secondNumber}");
        }).Sum();
    }
    
    private string ReplaceWrittenNumberWithDigit(string word)
    {
        return _writtenNumbersToDigit.TryGetValue(word, out var digit) ? digit : word;
    }

    private CalibrationResult FindFirstAndLastNumbers(string text)
    {
        var matches = Regex.Matches(text, @"(?=(one|two|three|four|five|six|seven|eight|nine|1|2|3|4|5|6|7|8|9))", RegexOptions.IgnoreCase);
       
        var firstMatch = matches.First().Groups[1].Value;
        var lastMatch = matches.Last().Groups[1].Value;
                
        return new CalibrationResult(firstMatch, lastMatch);
    }
}