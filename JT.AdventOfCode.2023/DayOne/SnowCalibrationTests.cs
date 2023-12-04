namespace JT.AdventOfCode._2023.DayOne;

public class SnowCalibrationTests : InputReader
{
    private readonly string[] _gameInput = InputByLine("DayOne");
    private readonly SnowCalibration _snowCalibration = new();

    [Fact]
    public void PartOne_SampleInput_ReturnsSumOfDigits()
    {
        var input = InputByLine("DayOne", "sample-1.txt");
        Assert.Equal(142, _snowCalibration.Calculate(input));
    }

    [Fact]
    public void PartOne_FullInput_ReturnsSumOfDigits()
    {
        Assert.Equal(54573, _snowCalibration.Calculate(_gameInput));
    }

    [Fact]
    public void PartTwo_SampleInput_ReturnsSumOfDigits_And_WrittenNumbers()
    {
        var input = InputByLine("DayOne", "sample-2.txt");
        Assert.Equal(281, _snowCalibration.CalculateWithWrittenNumbers(input));
    }
    
    [Fact]
    public void PartTwo_FullInput_ReturnsSumOfDigits_And_WrittenNumbers()
    {
        Assert.Equal(54591, _snowCalibration.CalculateWithWrittenNumbers(_gameInput));
    }

    [Fact]
    public void ReplaceOverlappingNumbersCorrectly()
    {
        Assert.Equal(18, _snowCalibration.CalculateWithWrittenNumbers(new []{"goneight"}));
    }
}

