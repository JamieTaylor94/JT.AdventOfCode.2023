namespace JT.AdventOfCode._2023.DayOne;

public class DayOneTests
{
    private static readonly string FilePath = $"{Directory.GetCurrentDirectory()}/DayOne/Resources";
    private readonly SnowCalibration _snowCalibration = new();

    [Fact]
    public void PartOne_SampleInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/sample-1.txt");
        Assert.Equal(142, _snowCalibration.Calculate(lines));
    }

    [Fact]
    public void PartOne_FullInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/day1.txt");
        Assert.Equal(54573, _snowCalibration.Calculate(lines));
    }

    [Fact]
    public void PartTwo_SampleInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/sample-2.txt");
        Assert.Equal(281, _snowCalibration.CalculateWithWrittenNumbers(lines));
    }
    
    [Fact]
    public void PartTwo_FullInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/day1.txt");
        Assert.Equal(54591, _snowCalibration.CalculateWithWrittenNumbers(lines));
    }

    [Fact]
    public void ReplaceOverlappingNumbersCorrectly()
    {
        Assert.Equal(18, _snowCalibration.CalculateWithWrittenNumbers(new []{"goneight"}));
    }
}

